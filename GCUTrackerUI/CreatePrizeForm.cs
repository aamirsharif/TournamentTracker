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
    public partial class CreatePrizeForm : Form
    {
        //Prize requestor to hold the info of the form that is requesting the prize info (Tournament form in this app)
        IPrizeRequester prizeRequester;
        /// <summary>
        /// Initializes the Prize form.
        /// </summary>
        /// <param name="requester">The specific requestor.</param>
        public CreatePrizeForm(IPrizeRequester requester)
        {
            InitializeComponent();
            prizeRequester = requester;
        }

        /// <summary>
        /// This method launches when user clicks the create prize button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void createPrizeButton_Click(object sender, EventArgs e)
        {
            //Check if user has given valid prize data.
            if (isFormValid())
            {
                //Create the prize and pass in the info
                Prize prize = new Prize(
                    placeNumberValue.Text,
                    placeNameValue.Text,
                    amountValue.Text,
                    percentageValue.Text);

                //Upload the prize info to the database
                DataConfig.connection.CreatePrize(prize);
                MessageBox.Show("Prize Created SuccessFully!!");

                //Alert the requestor that prize has been created (In this app prize is saved in the relevant tournament which requested the prize)
                prizeRequester.prizeCreated(prize);
                this.Close();
            }

            //If prize fields are not valid, then show an error box.
            else
                MessageBox.Show("The Form has Invalid Information. Please Check All The Fields","Prize Form",MessageBoxButtons.OK,MessageBoxIcon.Error);
        }

        /// <summary>
        /// This method checks the values entered in create prize form and validates them.
        /// </summary>
        /// <returns>Validity of the form.</returns>
        private bool isFormValid()
        {
            bool isValid = true;

            //Place Number
            int placeNumber = 0;
            
            //This parses the place number and checks if the user entered correct place value.
            //Returns true if value is correct
            bool isPlaceNumValid = int.TryParse(placeNumberValue.Text, out placeNumber);

            //If user did not enter the place number or entered a negative place number
            if (!isPlaceNumValid || placeNumber < 1)
                isValid = false;

            //If the user did not enter the value of Place Name
            if (placeNameValue.Text.Length == 0)
                isValid = false;

            double prizeAmount = 0;
            double prizePercent = 0;

            //Check if either amount or percentage is valid or not
            bool isAmountValid = double.TryParse(amountValue.Text, out prizeAmount);
            bool isPercentValid = double.TryParse(percentageValue.Text, out prizePercent);

            //If user did not enter amount or percentage
            if (!isAmountValid || !isPercentValid)
                isValid = false;

            //If prize amount and prize percent is either 0 or negative
            if (prizeAmount <= 0 && prizePercent <=0)
                isValid = false;

            //If percent is less than zero or greater than 100
            if (prizePercent < 0 || prizePercent > 100)
                isValid = false;

            return isValid;
        }
    }
}
