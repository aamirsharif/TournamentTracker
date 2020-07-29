using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCUTrackerLibrary.Models
{
    public class Prize
    {
        /// <summary>
        /// Unique identity for the prize.
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// Represents the nuber of position of the prize holder
        /// </summary>
        public int PlaceNumber { get; set; }
        /// <summary>
        /// Represents the name of the prize.
        /// </summary>
        public string PlaceName { get; set; }
        /// <summary>
        /// Represents the amount of the prize
        /// </summary>
        public double Amount { get; set; }
        /// <summary>
        /// Represents the percetage of the prize.
        /// </summary>
        public double Percentage { get; set; }

        public Prize()
        {

        }
        /// <summary>
        /// Overloaded constructor.
        /// </summary>
        /// <param name="place">Place Number of the Prize.</param>
        /// <param name="name">Place name of the Prize.</param>
        /// <param name="amount">Amount of the Prize.</param>
        /// <param name="percentage">Percentage of the Prize.</param>
        public Prize(string place, string name, string amount, string percentage)
        {
            int prizePlace = 0;
            int.TryParse(place, out prizePlace);
            this.PlaceNumber = prizePlace;

            this.PlaceName = name;

            double prizeMoney = 0;
            double.TryParse(amount, out prizeMoney);
            this.Amount = prizeMoney;

            double prizePercentage = 0;
            double.TryParse(percentage, out prizePercentage);
            this.Percentage = prizePercentage;
        }
    }
}
