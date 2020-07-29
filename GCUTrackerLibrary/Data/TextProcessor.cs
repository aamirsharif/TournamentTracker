using GCUTrackerLibrary.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GCUTrackerLibrary.Data.TextConnectorHelper
{
    public static class TextProcessor
    {
        /// <summary>
        /// Gets the file path for the file to be loaded
        /// </summary>
        /// <param name="filename">Name of file</param>
        /// <returns>Path of the file.</returns>
        public static string getFilePath(this string filename)
        {
            return $"{ConfigurationManager.AppSettings["filePath"] }\\{filename}";
        }

        /// <summary>
        /// Loads The contents of the prizes from the file.
        /// </summary>
        /// <param name="file">Path of the file.</param>
        /// <returns>Contents of the file.</returns>
        public static List<string> LoadFile(this string file)
        {
            if (!File.Exists(file))
                return new List<string>();
            return File.ReadAllLines(file).ToList();
        }

        /// <summary>
        /// Converts the list of file into Prizes.
        /// </summary>
        /// <param name="prizeLines">Contents of the file.</param>
        /// <returns>List of prizes.</returns>
        public static List<Prize> convertToPrize(this List<string> prizeLines)
        {
            List<Prize> prizes = new List<Prize>();
            foreach(string line in prizeLines)
            {
                string[] columns = line.Split(',');

                Prize prize = new Prize();
                prize.id = int.Parse(columns[0]);
                prize.Place = int.Parse(columns[1]);
                prize.Name = columns[2];
                prize.Amount = double.Parse(columns[3]);
                prize.Percent = double.Parse(columns[4]);

                prizes.Add(prize);
            }

            return prizes;
        }

        /// <summary>
        /// Converts the list of file into persons.
        /// </summary>
        /// <param name="personLines">List containing person info.</param>
        /// <returns>List of Persons.</returns>
        public static List<Person> convertToPerson(this List<string> personLines)
        {
            List<Person> persons = new List<Person>();
            foreach (string line in personLines)
            {
                string[] columns = line.Split(',');

                Person person = new Person();
                person.id = int.Parse(columns[0]);
                person.FirstName = columns[1];
                person.LastName = columns[2];
                person.Email = columns[3];
                person.MobileNo = columns[4];

                persons.Add(person);
            }

            return persons;
        }
        /// <summary>
        /// Saves all the prizes into the file.
        /// </summary>
        /// <param name="prizes">List of prizes to be saved.</param>
        /// <param name="filename">Filename where prizes are to be saved.</param>
        public static void SavePrizes(this List<Prize> prizes, string filename)
        {
            List<string> prizelines = new List<string>();

            //Add all the prizes into the list.
            foreach(Prize prize in prizes)
            {
                prizelines.Add($"{prize.id},{prize.Place},{prize.Name},{prize.Amount},{prize.Percent}");
            }

            //Write all the contents into the file
            File.WriteAllLines(filename.getFilePath(), prizelines);
        }

        /// <summary>
        /// Saves all the persons into the file.
        /// </summary>
        /// <param name="persons">List of persons to be saved.</param>
        /// <param name="filename">Filename where persons are to be saved.</param>
        public static void SavePersons(this List<Person> persons, string filename)
        {
            List<string> personlines = new List<string>();

            //Add all the persons into the list.
            foreach (Person person in persons)
            {
                personlines.Add($"{person.id},{person.FirstName},{person.LastName},{person.Email},{person.MobileNo}");
            }

            //Write all the contents into the file
            File.WriteAllLines(filename.getFilePath(), personlines);
        }

        /// <summary>
        /// Converts the list of file into teams
        /// </summary>
        /// <param name="teamLines">List containing teams info.</param>
        /// <param name="personFileName">File containing team members info.</param>
        /// <returns>List of Teams.</returns>
        public static List<Team> convertToTeam(this List<string> teamLines, string personFileName)
        {
            List<Team> teams = new List<Team>();
            List<Person> teamMembers = personFileName.getFilePath().LoadFile().convertToPerson();
            foreach(string line in teamLines)
            {
                string[] columns = line.Split(',');
                Team team = new Team();
                team.id = int.Parse(columns[0]);
                team.Name = columns[1];

                string[] memberIds = columns[2].Split('|');

                //Add all the team members into the team
                foreach(string id in memberIds)
                {
                    team.Members.Add(teamMembers.Where(x => x.id == int.Parse(id)).First());
                }
                teams.Add(team);
            }

            return teams;
        }

        public static List<Tournament> convertToTournament(this List<string> tournamentLines,
            string teamFileName,
            string peopleFileName,
            string prizeFileName)
        {
            List<Tournament> tournaments = new List<Tournament>();
            List<Team> teams = teamFileName.getFilePath().LoadFile().convertToTeam(peopleFileName);
            List<Prize> prizes = prizeFileName.getFilePath().LoadFile().convertToPrize();

            foreach(string line in tournamentLines)
            {
                string[] column = line.Split(',');
                Tournament tournament = new Tournament();
                tournament.id = int.Parse(column[0]);
                tournament.Name = column[1];
                tournament.EntryFee = double.Parse(column[2]);

                string[] teamIds = column[3].Split('|');
                foreach(string id in teamIds)
                {
                    tournament.Teams.Add(teams.Where(x => x.id == int.Parse(id)).First());
                }

                string[] prizeIds = column[4].Split('|');
                foreach(string id in prizeIds)
                {
                    tournament.Prizes.Add(prizes.Where(x => x.id == int.Parse(id)).First());
                }


                tournaments.Add(tournament);
            }

            return tournaments;
        }


        /// <summary>
        /// Saves Tournamnets into the tournament file.
        /// </summary>
        /// <param name="tournaments">List of tournaments to be saved.</param>
        /// <param name="tournamentFileName">File name where tournaments are to be saved.</param>
        public static void SaveTournaments(this List<Tournament> tournaments,string tournamentFileName)
        {
            List<string> lines = new List<string>();
            foreach(Tournament tournament in tournaments)
            {
                lines.Add($"{tournament.id},{tournament.Name},{tournament.EntryFee},{tournament.Teams.convertTeamsToList()}," +
                    $"{tournament.Prizes.convertPrizesToList()},{tournament.Rounds.convertRoundsToList()}");
            }
        }

        /// <summary>
        /// This method saves all the rounds into the file.
        /// </summary>
        /// <param name="tournament">Tournament containing matchups.</param>
        /// <param name="roundFile">FileName where rounds are to be saved.</param>
        /// <param name="matchupEntryFile">Filename where matchup entries are to be saved.</param>
        public static void SaveRounds(this Tournament tournament,string roundFile,string matchupEntryFile)
        {
            foreach(List<Matchup> round in tournament.Rounds)
            {
                foreach(Matchup matchup in round)
                {
                    matchup.SaveMatchup(roundFile);
                    
                }
            }
        }
        public static List<Matchup> convertToMatchup(this List<string> matchupLines)
        {
            List<Matchup> matchups = new List<Matchup>();

            foreach (string line in matchupLines)
            {
                string[] columns = line.Split(',');

                Matchup matchup = new Matchup();
                matchup.id = int.Parse(columns[0]);
                matchup.Entries = columns[1].convertStringToMatchupEntries();
                matchup.Winner = findByTeamId(int.Parse(columns[2]));
                matchup.Round = int.Parse(columns[3]);           
                matchups.Add(matchup);
            }

            return matchups;
        }

        private static Team findByTeamId(int id)
        {
            List<Team> teams = DataConfig.teamFile.getFilePath().LoadFile().convertToTeam(DataConfig.personFile);
            return teams.Where(x=> x.id == id).First();
        }
        private static List<MatchupEntry> convertStringToMatchupEntries(this string matchupLines)
        {
            string[] ids = matchupLines.Split('|');
            List<MatchupEntry> outputEntries = new List<MatchupEntry>();
            List<MatchupEntry> entries = DataConfig.matchupEntriesFile.getFilePath().LoadFile().convertToMatchupEntries();

            foreach (string id in ids)
            {
                outputEntries.Add(entries.Where(x => x.id == int.Parse(id)).First());
            }

            return outputEntries;
        }

        private static List<MatchupEntry> convertToMatchupEntries(this List<string> matchupLines)
        {
            List<MatchupEntry> entries = new List<MatchupEntry>();
            foreach(string line in matchupLines)
            {
                string[] columns = line.Split('^');
                MatchupEntry entry = new MatchupEntry();
                entry.id = int.Parse(columns[0]);
                entry.TeamCompeting = findByTeamId(int.Parse(columns[1]));
                entry.Score = double.Parse(columns[2]);
                int parentid = 0;
                if(int.TryParse(columns[3], out parentid))
                {
                    entry.ParentMatchup = findMatchupById(int.Parse(columns[3]));
                }else
                    entry.ParentMatchup = null;
                entries.Add(entry);
            }

            return entries;
        }

        private static Matchup findMatchupById(int id)
        {
            List<Matchup> matchups = DataConfig.roundsFile.getFilePath().LoadFile().convertToMatchup();
            return matchups.Where(x => x.id == id).First();
        }
        /// <summary>
        /// Saves the Matchup info in file.
        /// </summary>
        /// <param name="matchup">Matchup whose info is to be saved.</param>
        /// <param name="matchupFile">File where matchup info is to be saved.</param>
        public static void SaveMatchup(this Matchup matchup)
        {
            List<Matchup> matchups = DataConfig.roundsFile.getFilePath().LoadFile().convertToMatchup();

            int currentId = 1;
            if (matchups.Count > 0)
                currentId = matchups.OrderByDescending(x => x.id).First().id + 1;

            matchup.id = currentId;

            foreach (MatchupEntry entry in matchup.Entries)
            {
                entry.SaveMatchupEntry();
            }
        }

        /// <summary>
        /// Saves the MatchupEntry info in file.
        /// </summary>
        /// <param name="entry">Entry whose info is to be saved.</param>
        /// <param name="matchupEntryFile">File where info is to be saved.</param>
        public static void SaveMatchupEntry(this MatchupEntry entry)
        {

        }
        /// <summary>
        /// Saves all the teams into the file.
        /// </summary>
        /// <param name="teams">Teams to be saved.</param>
        /// <param name="fileName">File where teams are to be saved.</param>
        public static void SaveTeams(this List<Team> teams, string fileName)
        {
            List<string> teamlines = new List<string>();

            //Add all the teams into the list.
            foreach (Team team in teams)
            {
                teamlines.Add($"{team.id},{team.Name},{team.Members.convertPeopleToList()}");
            }

            //Write all the contents into the file
            File.WriteAllLines(fileName.getFilePath(), teamlines);
        }

        /// <summary>
        /// this method converts list of rounds into string of round ids separated by | character
        /// </summary>
        /// <param name="rounds"></param>
        /// <returns>String of rounds ids</returns>
        private static string convertRoundsToList(this List<List<Matchup>> rounds)
        {
            string list = "";
            //If there are no rounds
            if (rounds.Count == 0)
            {
                return list;
            }
            //Add the id of round to the list
            foreach (List<Matchup> round in rounds)
            {
                list += $"{round.convertMatchupsToList()}|";
            }

            //This removes the extra pipe character from the string
            list = list.Substring(0, list.Length - 1);
            return list;
        }
        /// <summary>
        /// This method converts each matchup into string of ids separated by ^ character
        /// </summary>
        /// <param name="matchups">List of Matchups</param>
        /// <returns>String ids of the matchup.</returns>
        private static string convertMatchupsToList(this List<Matchup> matchups)
        {
            string list = "";
            //If there are no matchups
            if (matchups.Count == 0)
                return list;

            //Add the id of each matchup in list
            foreach(Matchup matchup in matchups)
            {
                list += $"{matchup.id}^";
            }
            //This removes the extra ^ character from the string
            list = list.Substring(0, list.Length - 1);
            return list;
        }
        /// <summary>
        /// This method converts list of prizes into string of prize ids separated by | character.
        /// </summary>
        /// <param name="prizes">List of prizes.</param>
        /// <returns>String of prize ids.</returns>
        private static string convertPrizesToList(this List<Prize> prizes)
        {
            string list = "";
            //If there are no prizes
            if (prizes.Count == 0)
            {
                return list;
            }
            //Add the id of prize to the list
            foreach (Prize prize in prizes)
            {
                list += $"{prize.id}|";
            }

            //This removes the extra pipe character from the string
            list = list.Substring(0, list.Length - 1);
            return list;
        }
        /// <summary>
        /// This method converts list of Teams into string of team ids separated by | character.
        /// </summary>
        /// <param name="teams">List of teams.</param>
        /// <returns>String of team ids.</returns>
        private static string convertTeamsToList(this List<Team> teams)
        {
            string list = "";
            //If there are no teams
            if (teams.Count == 0)
            {
                return list;
            }
            //Add the id of team to the list
            foreach (Team team in teams)
            {
                list += $"{team.id}|";
            }

            //This removes the extra pipe character from the string
            list = list.Substring(0, list.Length - 1);
            return list;
        }
        /// <summary>
        /// This method converts list of people into string of ids separated by | character
        /// </summary>
        /// <param name="people">List of people</param>
        /// <returns>String of people ids.</returns>
        private static string convertPeopleToList(this List<Person> people)
        {
            string list = "";
            //If there are no people
            if(people.Count == 0)
            {
                return list;
            }
            //Add the id of people to the list
            foreach(Person person in people)
            {
                list += $"{person.id}|";
            }

            //This removes the extra pipe character from the string
            list = list.Substring(0, list.Length - 1);
            return list;
        }
    }
}
