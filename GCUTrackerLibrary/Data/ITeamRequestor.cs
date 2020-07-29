using GCUTrackerLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCUTrackerLibrary.Data
{
    /// <summary>
    /// Used by the forms to request the team information that has been created (Tournament form in this app)
    /// </summary>
    public interface ITeamRequestor
    {
        void teamCreated(Team team);
    }
}
