using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCUTrackerLibrary.Models
{
    public class MatchupEntry
    {
        /// <summary>
        /// Unique id of the matchupEntry
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// Represents MatchupId of current Matchup.
        /// </summary>
        public int MatchupId { get; set; }
        /// <summary>
        /// The id for the team competing.
        /// </summary>
        public int TeamCompetingId { get; set; }
        /// <summary>
        /// Represents the team competing for the matchup.
        /// </summary>
        public Team TeamCompeting { get; set; }
        /// <summary>
        /// Represents the score acquired by the team.
        /// </summary>
        public double Score { get; set; }
        /// <summary>
        /// The id for the parent matchup.
        /// </summary>
        public int ParentMatchupId { get; set; }
        /// <summary>
        /// Represents the matchup from which the team came as a winner.
        /// </summary>
        public Matchup ParentMatchup { get; set; }

    }
}
