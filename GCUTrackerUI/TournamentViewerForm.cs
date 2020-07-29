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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GCUTrackerUI
{
    public partial class TournamentViewerForm : Form
    {
        //Stores the tournament to be displayed on the form
        private Tournament tournament;

        //Create a binding list ot store the tournament rounds
        BindingList<int> rounds = new BindingList<int>();

        //Create a binding list to store the selected tournament matchups
        BindingList<Matchup> selectedMatchups = new BindingList<Matchup>();

        /// <summary>
        /// Initializes the tournament viewer form.
        /// </summary>
        /// <param name="tourn">Tournament whose info is to be displayed.</param>
        public TournamentViewerForm(Tournament tourn)
        {
            InitializeComponent();
            tournament = tourn;

            //Register the on completion event with the current tournament
            tournament.onCompletion += Tournament_onCompletion;

            //Refreshe the lists
            refreshLists();

            //Load the form
            LoadForm();

            //Load the rounds
            LoadRounds();
        }

        /// <summary>
        /// This event is called when a tournament is completed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tournament_onCompletion(object sender, DateTime e)
        {
            MessageBox.Show($"Tournament {tournament.TournamentName} Has been Finished!!","Tournament Complete",MessageBoxButtons.OK,MessageBoxIcon.Information);
            this.Close();
        }

        /// <summary>
        /// Loads the form.
        /// </summary>
        private void LoadForm()
        {
            tournamentName.Text = tournament.TournamentName;

        }
        /// <summary>
        /// Refreshes the contents of form lists
        /// </summary>
        private void refreshLists()
        {
            roundComboBox.DataSource = rounds;
            roundsListBox.DataSource = selectedMatchups;
            roundsListBox.DisplayMember = "DisplayName";
        }

        /// <summary>
        /// Loads the rounds of the tournaments
        /// </summary>
        private void LoadRounds()
        {
            //Clear the rounds list
            rounds.Clear();

            //Add first round number, since tournament has at least one round
            rounds.Add(1);
            int currentRound = 1;

            //Loop thorugh all rounds in the tournament
            foreach(List<Matchup> matchups in tournament.Rounds)
            {
                //If there are more than one rounds in the tournament, add them to the rounds list
                if(matchups.First().MatchupRound > currentRound)
                {
                    //Get the higher round number
                    currentRound = matchups.First().MatchupRound;
                    rounds.Add(currentRound);
                }
            }

            //Load matchups of the first round
            loadMatchups(1);
        }

        /// <summary>
        /// Called when user selects a different round from the list.
        /// Loads Matchups for the selected round.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void roundComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadMatchups((int)roundComboBox.SelectedItem);
        }

        /// <summary>
        /// Loads matchups for the round.
        /// </summary>
        /// <param name="round">Round number whose matchups are to be displayed.</param>
        private void loadMatchups(int round)
        {
            //Loop thorugh all the rounds in the tournament
            foreach(List<Matchup> matchups in tournament.Rounds)
            {
                //If the desired round is found
                if(matchups.First().MatchupRound == round)
                {
                    //Clear the matchups list from the form
                    selectedMatchups.Clear();

                    //Loop through all the matchups in the round
                    foreach(Matchup m in matchups)
                    {
                        //If the matchup is currently ongoing i.e no winner yet or the unplayed box is unchecked, add the matchup to the list
                        if(m.Winner == null || !unplayedCheckBox.Checked)
                        {
                            selectedMatchups.Add(m);
                        }
                        
                    }
                }
            }

            //If there are matchups in the round, then load the first matchup info
            if(selectedMatchups.Count > 0)
            {
                LoadMatchup(selectedMatchups.First());
            }

            //Display the info of matchup
            DisplayMatchupInfo();
           
        }

        /// <summary>
        /// Loads the matchup info into the tournament
        /// </summary>
        /// <param name="matchup">Matchup to be loaded.</param>
        private void LoadMatchup(Matchup matchup)
        {
            //If matchup does not exist, then return
            if (matchup == null)
                return;
            //Loop through all the matchup entries, at a time there are only two entries i.e two teams competing with each other
            for(int i=0;i<matchup.Entries.Count;i++)
            {
                if(i==0)
                {
                    //If the competing team of matchup exists, set the labels
                    if(matchup.Entries[0].TeamCompeting != null)
                    {
                        teamOneLabel.Text = matchup.Entries[0].TeamCompeting.TeamName;
                        teamOneScoreValue.Text = matchup.Entries[0].Score.ToString();

                        teamTwoLabel.Text = "-Bye-";
                        teamTwoScoreValue.Text = "0";
                    }
                    else
                    {
                        teamOneLabel.Text = "Not Yet Set";
                        teamOneScoreValue.Text = "";
                    }
                }
                else if(i == 1)
                {
                    //If the competing team exists, then set the labels
                    if (matchup.Entries[1].TeamCompeting != null)
                    {
                        teamTwoLabel.Text = matchup.Entries[1].TeamCompeting.TeamName;
                        teamTwoScoreValue.Text = matchup.Entries[1].Score.ToString();
                    }
                    else
                    {
                        teamTwoLabel.Text = "Not Yet Set";
                        teamTwoScoreValue.Text = "";
                    }
                }
            }
        }

        /// <summary>
        /// Displays the matchup info under give conditions.
        /// </summary>
        private void DisplayMatchupInfo()
        {
            bool isVisible = (selectedMatchups.Count > 0);
           
            teamOneLabel.Visible = isVisible;
            teamOneScoreLabel.Visible = isVisible;
            teamOneScoreValue.Visible = isVisible;

            teamTwoLabel.Visible = isVisible;
            teamTwoScoreLabel.Visible = isVisible;
            teamTwoScoreValue.Visible = isVisible;
           
            scoreButton.Visible = isVisible;
        }

        /// <summary>
        /// If user selects a different matchup from the matchups list, then load info of the selected matchup
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void roundsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMatchup((Matchup)roundsListBox.SelectedItem);
        }

        /// <summary>
        /// If user selects or deselects the unplayed only check box, then load matchups accordingly.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void unplayedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            loadMatchups((int)roundComboBox.SelectedItem);
        }

        /// <summary>
        /// Called when user clicks on the score button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void scoreButton_Click(object sender, EventArgs e)
        {
            //Check if scores are valid
            string scoresValidity = scoresValidMessage();
            if(scoresValidity.Length > 0)
            {
                MessageBox.Show($"{scoresValidity}","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            //Get the current matchup which is to be scored
            Matchup matchup = (Matchup)roundsListBox.SelectedItem;


            double teamOneScore = 0;
            double teamTwoScore = 0;

            //Loop through both entries of the matchup
            for (int i = 0; i < matchup.Entries.Count; i++)
            {
                if (i == 0)
                {
                    //If first entry has a valid competing team
                    if (matchup.Entries[0].TeamCompeting != null)
                    {

                        bool scoreValid = double.TryParse(teamOneScoreValue.Text, out teamOneScore);
                        if (scoreValid)
                        {
                            matchup.Entries[0].Score = teamOneScore;
                        }
                        else
                        {
                            MessageBox.Show("Please enter valid score for team 1.","Invalid Score",MessageBoxButtons.OK,MessageBoxIcon.Error);
                            return;
                        }

                    }
                }
                
                if (i == 1)
                {
                    //If second entry is a valid team
                    if (matchup.Entries[1].TeamCompeting != null)
                    {
                        
                        bool scoreValid = double.TryParse(teamTwoScoreValue.Text, out teamTwoScore);
                        
                        if (scoreValid)
                        {
                            matchup.Entries[1].Score = teamTwoScore;
                        }
                        else
                        {
                            MessageBox.Show("Please enter valid score for team 2.","Invalid Score",MessageBoxButtons.OK,MessageBoxIcon.Error);
                            return;
                        }

                    }
                    
                }
            }

            //Update the matchup results after scoring the matchup
            try
            {
                Logic.updateTournamentResults(tournament);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message }","Exception Occured",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            //Load matchups again.
            loadMatchups((int)roundComboBox.SelectedItem);
        }

        /// <summary>
        /// checks if the score is valid or not.
        /// </summary>
        /// <returns>Returns relevant message if score is invalid otherwise returns an empty string.</returns>
        private string scoresValidMessage()
        {
            string message = "";
            double teamOneScore = 0;
            double teamTwoScore = 0;

            bool scoreOneValid = double.TryParse(teamOneScoreValue.Text, out teamOneScore);
            bool scoreTwoValid = double.TryParse(teamTwoScoreValue.Text, out teamTwoScore);

            if(!scoreOneValid )
            {
                message = "Score One is not Valid";
            }

            else  if(!scoreTwoValid)
            {
                message = "Score Two is not Valid";
            }

            else if(teamOneScore == 0 && teamTwoScore == 0)
            {
                message = "Please Enter scores for teams";
            }

            else if(teamOneScore == teamTwoScore)
            {
                message = "We do not handle ties";
            }
            return message;
        }
    }
}
