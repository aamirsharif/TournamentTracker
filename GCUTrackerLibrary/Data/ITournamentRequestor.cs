using GCUTrackerLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCUTrackerLibrary.Data
{
    /// <summary>
    /// Used by the Dashboard so that it knows that a new tournament has been created.
    /// </summary>
    public interface ITournamentRequestor
    {
        void tournamentCreated(Tournament tournament);
    }
}
