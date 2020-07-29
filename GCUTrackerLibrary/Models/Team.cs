using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCUTrackerLibrary.Models
{
    public class Team
    {
        /// <summary>
        /// Represents the id of team
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// Represents the name of the team
        /// </summary>
        public string TeamName { get; set; }
        /// <summary>
        /// Represents members in the team
        /// </summary>
        public List<Person> Members { get; set; } = new List<Person>();
       
    }
}
