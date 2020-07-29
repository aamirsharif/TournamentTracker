using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCUTrackerLibrary.Models
{
    public class Matchup
    {
        /// <summary>
        /// Represents the id of each round.
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// Represents Id of the Tournament.
        /// </summary>
        public int TournamentId { get; set; }
        /// <summary>
        /// Represents each match entry in the round
        /// </summary>
        public List<MatchupEntry> Entries { get; set; } = new List<MatchupEntry>();
        /// <summary>
        /// The id from the database to identify the winner.
        /// </summary>
        public int WinnerId { get; set; }
        /// <summary>
        /// Represents the winning team of the matchup.
        /// </summary>
        public Team Winner { get; set; }
        /// <summary>
        /// Represents the Round of the matchup.
        /// </summary>
        public int MatchupRound { get; set; }
        /// <summary>
        /// This Property is used to display the name of matchup in the List box
        /// in the Tournament Viewer Form.
        /// </summary>
        public string DisplayName 
        { 
            get
            {
                string output = "";
                //Loop through each entry in the matchup
                foreach(MatchupEntry entry in Entries)
                {
                    //If a team is competing in the entry that is there is no bye week
                    if(entry.TeamCompeting != null)
                    {
                        //If output has zero length
                        if (output.Length == 0)
                        {
                            output = entry.TeamCompeting.TeamName;
                        }
                        //If a team is added then put versus label against next team
                        else
                            output += $" vs {entry.TeamCompeting.TeamName }";
                    }
                    //If matchup has not ben set yet
                    else
                    {
                        output = "Matchup not yet determined.";
                        break;
                    }
                    
                }
                return output;
            }
            }
    }
}
