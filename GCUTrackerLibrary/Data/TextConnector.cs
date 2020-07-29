using GCUTrackerLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCUTrackerLibrary.Data.TextConnectorHelper;

namespace GCUTrackerLibrary.Data
{
    public class TextConnector : IDataConnection
    {
        private const string prizeFile = "Prizes.csv";
        private const string personFile = "Persons.csv";
        private const string teamFile = "Teams.csv";
        private const string tournamentFile = "Tournaments.csv";
        private const string roundsFile = "Rounds.csv";
        private const string matchupEntriesFile = "MatchupEntries.csv";

        /// <summary>
        /// Loads persons from the file (If any) and adds a new person to it.
        /// </summary>
        /// <param name="person">Person to be added.</param>
        /// <returns>Person with its unique identity.</returns>
        public Person CreatePerson(Person person)
        {
            //Loads the file containing data of persons and convert them to persons and store them in a list.
            //Note: Extension Methods from TextProcessor class are used here.
            List<Person> personList = personFile.getFilePath().LoadFile().convertToPerson();

            //Find the maximum id of the persons in list  and assign it to the person.
            //If there is no person in file then first id will be 1
            int currentID = 1;

            //If file contains persons.
            if (personList.Count > 0)
                currentID = personList.OrderByDescending(x => x.id).First().id + 1;
            person.id = currentID;

            //Add the person into the persons with its id
            personList.Add(person);

            //Save all the persons into the file
            personList.SavePersons(personFile);

            return person;
        }

        /// <summary>
        /// Loads prizes from the file (if any) and adds a new prize to it.
        /// </summary>
        /// <param name="prize">Prize to be added.</param>
        /// <returns>Prize with its unique ID.</returns>
        public Prize CreatePrize(Prize prize)
        {
            //Loads the file containing data of prizes and convert them to prizes and store them in a list.
            //Note: Extension Methods from TextProcessor class are used here.
            List<Prize> prizesList = prizeFile.getFilePath().LoadFile().convertToPrize();

            //Find the maximum id of the prizes in list  and assign it to the prize.
            //If there is no prize in file then first id will be 1
            int currentID = 1;

            //If file contains prizes.
            if(prizesList.Count > 0)
                currentID = prizesList.OrderByDescending(x => x.id).First().id + 1;
            prize.id = currentID;

            //Add the prize into the prizes with its id
            prizesList.Add(prize);

            //Save all the prizes into the file
            prizesList.SavePrizes(prizeFile);

            return prize;
        }

        /// <summary>
        /// Loads teams from file (if any) and adds the new team to it
        /// </summary>
        /// <param name="team"></param>
        /// <returns>Team with its unique id.</returns>
        public Team CreateTeam(Team team)
        {
            //Loads the file containing data of teams and convert them to teams and store them in a list.
            //Note: Extension Methods from TextProcessor class are used here.
            List<Team> teamsList = teamFile.getFilePath().LoadFile().convertToTeam(personFile);

            //Find the maximum id of the teams in list  and assign it to the prize.
            //If there is no team in file then first id will be 1
            int currentID = 1;

            //If file contains teams.
            if (teamsList.Count > 0)
                currentID = teamsList.OrderByDescending(x => x.id).First().id + 1;
            team.id = currentID;

            //Add the team into the prizes with its id
            teamsList.Add(team);

            //Save all the prizes into the file
            teamsList.SaveTeams(teamFile);

            return team;
        }

        /// <summary>
        /// Stores the tournament info into the file.
        /// </summary>
        /// <param name="tournament">Tournament to be stored.</param>
        /// <returns>Tournament with its unique Id.</returns>
        public Tournament CreateTournament(Tournament tournament)
        {
            //Loads the file containing data of teams and convert them to teams and store them in a list.
            //Note: Extension Methods from TextProcessor class are used here.
            List<Tournament> tournamentList = tournamentFile.getFilePath().LoadFile().convertToTournament(teamFile,personFile,prizeFile);

            //Find the maximum id of the teams in list  and assign it to the prize.
            //If there is no team in file then first id will be 1
            int currentID = 1;

            //If file contains teams.
            if (tournamentList.Count > 0)
                currentID = tournamentList.OrderByDescending(x => x.id).First().id + 1;
            tournament.id = currentID;

            //Add the team into the prizes with its id
            tournamentList.Add(tournament);

            //Save all the prizes into the file
            tournamentList.SaveTournaments(tournamentFile);

            return tournament;
        }

        /// <summary>
        /// Gets the list of Person from file.
        /// </summary>
        /// <returns>List of persons.</returns>
        public List<Person> getAllPersons()
        {
            return personFile.getFilePath().LoadFile().convertToPerson();
        }

        /// <summary>
        /// Gets the list of teams from file.
        /// </summary>
        /// <returns>List of teams.</returns>
        public List<Team> getAllTeams()
        {
            return teamFile.getFilePath().LoadFile().convertToTeam(personFile);
        }
    }
}
