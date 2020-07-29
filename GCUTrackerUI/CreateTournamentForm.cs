using GCUTrackerLibrary;
using GCUTrackerLibrary.Data;
using GCUTrackerLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GCUTrackerUI
{
    /// <summary>
    /// This form implements the prize and team requestor interface
    /// </summary>
    public partial class CreateTournamentForm : Form,IPrizeRequester,ITeamRequestor
    {
        //Holds the tournament requestor info
        ITournamentRequestor tournamentRequestor;

        //Get all the teams available in the database
        List<Team> availableTeams = DataConfig.connection.getAllTeams();
        
        //Create a list for selected teams
        List<Team> selectedTeams = new List<Team>();
        
        //Create a list for selected prizes
        List<Prize> selectedPrizes = new List<Prize>();

        /// <summary>
        /// Initializes the form
        /// </summary>
        public CreateTournamentForm(ITournamentRequestor requestor)
        {
            InitializeComponent();
            tournamentRequestor = requestor;
            refreshLists();
        }

        /// <summary>
        /// Refreshes the contents of the lists
        /// </summary>
        private void refreshLists()
        {
            //Refresh the list of available teams
            selectTeamComboBox.DataSource = null;
            selectTeamComboBox.DataSource = availableTeams;
            selectTeamComboBox.DisplayMember = "TeamName";

            //Refresh the list of selected teams
            tournamentPlayersListBox.DataSource = null;
            tournamentPlayersListBox.DataSource = selectedTeams;
            tournamentPlayersListBox.DisplayMember = "TeamName";

            //Refresh the list of prizes
            tournamentPrizesListBox.DataSource = null;
            tournamentPrizesListBox.DataSource = selectedPrizes;
            tournamentPrizesListBox.DisplayMember = "PlaceName";
        }

        /// <summary>
        /// Called when user clicks the add team button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addTeamButton_Click(object sender, EventArgs e)
        {
            //Get the selected team
            Team team = (Team)selectTeamComboBox.SelectedItem;

            //If user selected a team
            if(team != null)
            {
                selectedTeams.Add(team);
                availableTeams.Remove(team);
                //Refresh the lists
                refreshLists();
            }
        }

        /// <summary>
        /// Called when user wants to create a prize, opens the create prize form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void createPrizeButton_Click(object sender, EventArgs e)
        {
            CreatePrizeForm prizeForm = new CreatePrizeForm(this);
            prizeForm.Show();
        }

        /// <summary>
        /// When a prize is created, this form is notified by the prize form.
        /// </summary>
        /// <param name="prize"></param>
        public void prizeCreated(Prize prize)
        {
            //If prize is created, then add it to the selected prizes list
            if(prize != null)
            {
                selectedPrizes.Add(prize);
                refreshLists();
            }
            
        }

        /// <summary>
        /// When a team is created, this form is notified by the team form
        /// </summary>
        /// <param name="team"></param>
        public void teamCreated(Team team)
        {
            //If team is created, add it to the selected teams list.
            if(team != null)
            {
                selectedTeams.Add(team);
                refreshLists();
            }
        }

        /// <summary>
        /// Called when user clicks on the create team button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void createTeamButton_Click(object sender, EventArgs e)
        {
            CreateTeamForm teamform = new CreateTeamForm(this);
            teamform.Show();
        }

        /// <summary>
        /// Called when user wants to remove a team from the tournament.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void removePlayersButton_Click(object sender, EventArgs e)
        {
            //Get the team to be removed
            Team team = (Team)tournamentPlayersListBox.SelectedItem;
            
            //If user selected a team
            if(team != null)
            {
                availableTeams.Add(team);
                selectedTeams.Remove(team);

                refreshLists();
            }
        }

        /// <summary>
        /// Called when user wants to remove a prize from the tournament.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void removePrizesButton_Click(object sender, EventArgs e)
        {
            //Get te prize o be removed
            Prize prize = (Prize)tournamentPrizesListBox.SelectedItem;
            
            //If user selected a prize
            if(prize != null)
            {
                selectedPrizes.Remove(prize);
                refreshLists();
            }
        }

        /// <summary>
        /// This method is called when user clicks on the create tournament button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void createTournamentButton_Click(object sender, EventArgs e)
        {
            //Check if user has entered valid data
            if (isTournamnetValid())
            {
                //Create the tournament
                Tournament tournament = new Tournament();
                tournament.EntryFee = double.Parse(entryFeeValue.Text);
                tournament.TournamentName = tournamentNameValue.Text;
                tournament.Prizes = selectedPrizes;
                tournament.Teams = selectedTeams;
                
                //Create the rounds for the tournament
                Logic.createRounds(tournament);

                //After rounds are created, upload the tournament to the database
                DataConfig.connection.CreateTournament(tournament);

                //Notify tournament members by email about their matchups in rounds
                Logic.alertUsersToNewRound(tournament);

                //Notify the requestor that tournament has been created
                tournamentRequestor.tournamentCreated(tournament);

                MessageBox.Show($"Tournament {tournament.TournamentName} has been Created Successfully","Tournament Created",MessageBoxButtons.OK,MessageBoxIcon.Information);
                
                //Open the tournament viewer form
                TournamentViewerForm form = new TournamentViewerForm(tournament);
                form.Show();
                this.Close();
            }
            else
                MessageBox.Show("There are some invalid fields. Please Check fields again" +
                    "\nNote: 1) Teams cannot be less than two.\n" +
                    "2) Fee cannot be less than zero.","Fileds missing",MessageBoxButtons.OK,MessageBoxIcon.Error);
        }

        /// <summary>
        /// Validates the tournament form
        /// </summary>
        /// <returns></returns>
        private bool isTournamnetValid()
        {
            bool isValid = true;

            //If name is not valid
            if(tournamentNameValue.Text.Length == 0)
            {
                isValid = false;
            }

            double fee = 0;
            Double.TryParse(entryFeeValue.Text, out fee);

            //If fee is less than zero
            if (fee <= 0)
                isValid = false;

            //Teams less than 2 are not allowed in the tournament.
            if (selectedTeams.Count < 2)
                isValid = false;

            return isValid;
        }
    }
}
