using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GCUTrackerLibrary.Models
{
    public class Tournament
    {
        /// <summary>
        /// Represents the id of the tournament.
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// Represents the name of the tournament.
        /// </summary>
        public string TournamentName { get; set; }
        /// <summary>
        /// Represents the entry fee for the tournament.
        /// </summary>
        public double EntryFee { get; set; }
        /// <summary>
        /// Represents the list of teams participating
        /// in the tournament.
        /// </summary>
        public List<Team> Teams { get; set; } = new List<Team>();
        /// <summary>
        /// Represents the Prizes set for this particular tournament.
        /// </summary>
        public List<Prize> Prizes { get; set; } = new List<Prize>();
        /// <summary>
        /// Represents the rounds for this particular tournament.
        /// </summary>
        public List<List<Matchup>> Rounds { get; set; } = new List<List<Matchup>>();

        //This event is launched when A tournament is completed
        public event EventHandler<DateTime> onCompletion;

        //This method invokes the event
        public void Complete()
        {
            onCompletion?.Invoke(this, DateTime.Now);
        }
    }
}
