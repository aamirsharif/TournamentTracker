using GCUTrackerLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCUTrackerLibrary.Data
{
    /// <summary>
    /// This interface is used by the tournament form which creates the prize.
    /// </summary>
    public interface IPrizeRequester
    {
        void prizeCreated(Prize prize);
    }
}
