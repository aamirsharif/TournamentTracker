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
    public partial class CreateTeamForm : Form
    {
        //Get the list of all the persons available in the database
        private List<Person> availableMembers = DataConfig.connection.getAllPersons();
        //Create a list of selected members
        private List<Person> selectedMembers = new List<Person>();
        //Holds the team requestor object (Tournament form in this app)
        ITeamRequestor teamRequestor;

        /// <summary>
        /// Initializes the team form.
        /// </summary>
        /// <param name="requestor">Object that is requesting the team info. (tournament in this app)</param>
        public CreateTeamForm(ITeamRequestor requestor)
        {
            InitializeComponent();
            teamRequestor = requestor;
            refreshLists();
        }

        /// <summary>
        /// This method refreshes the contents of the lists of team form.
        /// </summary>
        private void refreshLists()
        {
            //Refresh the availale members list
            selectTeamMemberComboBox.DataSource = null;
            selectTeamMemberComboBox.DataSource = availableMembers;
            selectTeamMemberComboBox.DisplayMember = "FullName";

            //Refreshes the selected members
            teamMembersListBox.DataSource = null;
            teamMembersListBox.DataSource = selectedMembers;
            teamMembersListBox.DisplayMember = "FullName";
        }

        /// <summary>
        /// This method adds new member into the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void createMemberButton_Click(object sender, EventArgs e)
        {
            //Check if user has entered valid members data
            if(IsMembersFormValid())
            {
                //Create the person
                Person person = new Person(
                    firstNameValue.Text,
                    lastNameValue.Text,
                    emailValue.Text,
                    mobileNumberValue.Text);

                //Upload the person in the database
                DataConfig.connection.CreatePerson(person);

                //Add the person to the selected members list
                selectedMembers.Add(person);
                refreshLists();

                MessageBox.Show("New Member Created SuccessFully!!","Member Created",MessageBoxButtons.OK,MessageBoxIcon.Information);
                
                //Reset the labels
                firstNameValue.Text = "";
                lastNameValue.Text = "";
                emailValue.Text = "";
                mobileNumberValue.Text = "";
            }
            else
                //If form has invalid data
                MessageBox.Show("The Form has Invalid Information. Please Check All The Fields","Error in Info",MessageBoxButtons.OK,MessageBoxIcon.Error);
        }

        /// <summary>
        /// This method checks if fileds of adding new member are valid or not.
        /// </summary>
        /// <returns>Validity of new member form.</returns>
        private bool IsMembersFormValid()
        {
            bool isValid = true;
            if (firstNameValue.Text.Length == 0)
                isValid = false;
            if (lastNameValue.Text.Length == 0)
                isValid = false;
            if (emailValue.Text.Length == 0 || !IsValidEmail(emailValue.Text))
                isValid = false;
            if (mobileNumberValue.Text.Length == 0)
                isValid = false;
            return isValid;
        }

        /// <summary>
        /// This method checks if an email is valid or not
        /// </summary>
        /// <param name="email"></param>
        /// <returns>Validity of an email.</returns>
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// This method is called when user clicks the add member button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addMemberButton_Click(object sender, EventArgs e)
        {
            //Get the selected person from list
            Person person = (Person)selectTeamMemberComboBox.SelectedItem;
            
            //If user has selected a person
            if(person != null)
            {
                availableMembers.Remove(person);
                selectedMembers.Add(person);
            }
            //Refresh the lists
            refreshLists();
        }

        /// <summary>
        /// Called when user wants to remove a person from selected members.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void removeSelectedMembersButton_Click(object sender, EventArgs e)
        {
            //Get the selected person
            Person person = (Person)teamMembersListBox.SelectedItem;
            
            //If user selected  aperson
            if (person != null)
            {
                selectedMembers.Remove(person);
                availableMembers.Add(person);
            }

            //Refresh lists
            refreshLists();
        }

        /// <summary>
        /// Creates a new Team
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void createTeamButton_Click(object sender, EventArgs e)
        {
            //If team info is valid
            if (teamNameValue.Text.Length != 0 && selectedMembers.Count > 0)
            {
                //Create the team
                Team team = new Team();

                //Get the team name and selected members
                team.TeamName = teamNameValue.Text;
                team.Members = selectedMembers;

                //Upload the info to the database
                DataConfig.connection.CreateTeam(team);
                MessageBox.Show($"Team {team.TeamName} has been Created Successfully.","Team Created",MessageBoxButtons.OK,MessageBoxIcon.Information);

                //Alert the team requestor that team has been created
                teamRequestor.teamCreated(team);
                this.Close();
            }
            else if(selectedMembers.Count == 0)
                MessageBox.Show("Please Select some Team Members.","Members not selected",MessageBoxButtons.OK,MessageBoxIcon.Error);
            else
                MessageBox.Show("Please Enter Team Name.","Name not entered",MessageBoxButtons.OK,MessageBoxIcon.Error);

        }
    }
}
