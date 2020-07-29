using GCUTrackerLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCUTrackerLibrary.Data
{
    /// <summary>
    /// Interface used by databases to connect with the application
    /// </summary>
    public interface IDataConnection
    {
        void CreatePrize(Prize prize);
        void CreatePerson(Person person);
        void CreateTeam(Team team);
        void CreateTournament(Tournament tournament);
        void CompleteTournament(Tournament tournament);
        List<Person> getAllPersons();
        List<Team> getAllTeams();
        List<Tournament> getAllTournaments();
        void UpdateMatchup(Matchup matchup);
    }
}
