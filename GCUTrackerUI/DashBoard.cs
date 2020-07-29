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
    public partial class DashBoard : Form, ITournamentRequestor
    {
        //Get all tournaments from the database
        List<Tournament> tournaments = DataConfig.connection.getAllTournaments();

        public DashBoard()
        {
            InitializeComponent();
            refreshLists();

            foreach(Tournament tournament in tournaments)
            {
                tournament.onCompletion += Tournament_onCompletion;
            }
        }

        /// <summary>
        /// Event called when tournament is completed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tournament_onCompletion(object sender, DateTime e)
        {
            tournaments = DataConfig.connection.getAllTournaments();
            refreshLists();
        }

        //Refreshes the tournaments list
        private void refreshLists()
        {
            loadTournamentComboBox.DataSource = null;
            loadTournamentComboBox.DataSource = tournaments;
            loadTournamentComboBox.DisplayMember = "TournamentName";
        }

        /// <summary>
        /// Called when user wants to create a new tournament
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void createNewButton_Click(object sender, EventArgs e)
        {
            CreateTournamentForm form = new CreateTournamentForm(this);
            form.Show();
        }

        /// <summary>
        /// Called when user wants to load a tournament.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadTournamentButton_Click(object sender, EventArgs e)
        {
            //Get the tournament to be loaded
            Tournament tournament = (Tournament)loadTournamentComboBox.SelectedItem;
            TournamentViewerForm form;
            
            //If tournament is selected
            if (tournament != null)
            {
                form = new TournamentViewerForm(tournament);
                form.Show();
            }
            else
            {
                MessageBox.Show("Please Select a Tournament to be opened.", "Select a Tournament", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
                
        }

        /// <summary>
        /// Called when a new tournament is created by the create tournament form
        /// </summary>
        /// <param name="tournament"></param>
        public void tournamentCreated(Tournament tournament)
        {
            //If tournament is created
            if(tournament!= null)
            {
                tournament.onCompletion += Tournament_onCompletion;
                tournaments = DataConfig.connection.getAllTournaments();
                refreshLists();
            }
        }
    }
}
