using GCUTrackerLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace GCUTrackerLibrary.Data
{
    public class MSSqlConnector : IDataConnection
    {
        /// <summary>
        /// Stores Person Information into the Database.
        /// </summary>
        /// <param name="person">Informatio about the Person.</param>
        public void CreatePerson(Person person)
        {
            //Creates a database connection using the IDbConnection interface.
            //getConnectionString Method provides the connection string

            using (IDbConnection connection = new SqlConnection(DataConfig.getConnectionString("GCUTournaments")))
            {
                //Create a list of dynamic parameters so that they can be added to the database
                //Add the person info into the list

                var list = new DynamicParameters();
                list.Add("@FirstName", person.FirstName);
                list.Add("@LastName", person.LastName);
                list.Add("@Email", person.Email);
                list.Add("@MobileNo", person.CellPhone);
                list.Add("@ID", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                //Run the stored procedure to insert the prize and get the prize id
                connection.Execute("dbo.ProcInsertPerson", list, commandType: CommandType.StoredProcedure);

                //Get the id assigned to the prize from the database
                person.id = list.Get<int>("@ID");
            }
        }

        /// <summary>
        /// Stores Prize Information into the database.
        /// </summary>
        /// <param name="prize">Information about the prize.</param>
        public void CreatePrize(Prize prize)
        {
            //Creates a database connection using the IDbConnection interface.
            //getConnectionString Method provides the connection string

            using (IDbConnection connection = new SqlConnection(DataConfig.getConnectionString("GCUTournaments")))
            {
                //Create a list of dynamic parameters so that they can be added to the database
                //Add the prize info into the list

                var list = new DynamicParameters();
                list.Add("@PlaceNumber", prize.PlaceNumber);
                list.Add("@PlaceName", prize.PlaceName);
                list.Add("@Amount", prize.Amount);
                list.Add("@Percentage", prize.Percentage);
                list.Add("@ID", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                //Run the stored procedure to insert the prize and get the prize id
                connection.Execute("dbo.ProcInsertPrize", list, commandType: CommandType.StoredProcedure);

                //Get the id assigned to the prize from the database
                prize.id = list.Get<int>("@ID");
            }          
        }
        /// <summary>
        /// Stores Team Information into the Database
        /// </summary>
        /// <param name="team">Team to be stored.</param>
        public void CreateTeam(Team team)
        {
            //Creates a database connection using the IDbConnection interface.
            //getConnectionString Method provides the connection string

            using (IDbConnection connection = new SqlConnection(DataConfig.getConnectionString("GCUTournaments")))
            {
                //Create a list of dynamic parameters so that they can be added to the database
                //Add the team info into the list

                var list = new DynamicParameters();
                list.Add("@TeamName", team.TeamName);
                list.Add("@ID", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                //Run the stored procedure to insert the team and get the prize id
                connection.Execute("dbo.procInsertTeam", list, commandType: CommandType.StoredProcedure);
                //Get the id assigned to the team from the database
                team.id = list.Get<int>("@ID");

                foreach (Person member in team.Members)
                {
                    list = new DynamicParameters();
                    list.Add("@TeamID", team.id);
                    list.Add("@PersonID", member.id);

                    //Run the stored procedure to insert the team member and get the prize id
                    connection.Execute("dbo.procInsertTeamMember", list, commandType: CommandType.StoredProcedure);
                }
            }
        }

        /// <summary>
        /// Stores Tournament info into the database
        /// </summary>
        /// <param name="tournament">Tournament to be stored.</param>
        public void CreateTournament(Tournament tournament)
        {
            //Creates a database connection using the IDbConnection interface.
            //getConnectionString Method provides the connection string

            using (IDbConnection connection = new SqlConnection(DataConfig.getConnectionString("GCUTournaments")))
            {
                saveTournament(connection, tournament);
                savePrizes(connection, tournament);
                saveTeams(connection, tournament);
                saveRounds(connection, tournament);
                Logic.updateTournamentResults(tournament);
            }
        }

        /// <summary>
        /// Saves Tournament Rounds info into the database.
        /// </summary>
        /// <param name="connection">Connection of database</param>
        /// <param name="tournament">Tournament whose rounds are to be saved.</param>
        private void saveRounds(IDbConnection connection,Tournament tournament)
        {
            //Loop through each round in tournament
            foreach(List<Matchup> round in tournament.Rounds)
            {
                //Loop through each matchup in the rounds
                foreach(Matchup matchup in round)
                {
                    //Create a list of dynamic parameters and add the info to it
                    var list = new DynamicParameters();
                    list.Add("@TournamentId", tournament.id);
                    list.Add("@MatchupRound", matchup.MatchupRound);
                    list.Add("@ID", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                    connection.Execute("dbo.procInsertMatchups", list, commandType: CommandType.StoredProcedure);

                    //Get the unique id of matchup from the database
                    matchup.id = list.Get<int>("@ID");

                    //After inserting the matchup, loop through each entry in the matchup
                    foreach(MatchupEntry entry in matchup.Entries)
                    {
                        list = new DynamicParameters();
                        list.Add("@MatchupId", matchup.id);

                        //If the entry is the first match in tournament
                        if(entry.ParentMatchup == null)
                        {
                            list.Add("@ParentMatchupId", null);
                        }
                        else
                            list.Add("@ParentMatchupId", entry.ParentMatchup.id);

                        //If the entry has no team, that is it is a bye week
                        if(entry.TeamCompeting == null)
                        {
                            list.Add("@TeamCompetingId", null);
                        }
                        else
                            list.Add("@TeamCompetingId", entry.TeamCompeting.id);

                        list.Add("@ID", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);


                        //Insert the matchup entry in database and get its unique id
                        connection.Execute("dbo.procInsertMatchupEntry", list, commandType: CommandType.StoredProcedure);
                        entry.id = list.Get<int>("@ID");
                    }
                }
            }
        }
        /// <summary>
        /// Saves the tournament info in database.
        /// </summary>
        /// <param name="connection">Connecton of database.</param>
        /// <param name="tournament">Tournament info to be saved.</param>
        private void saveTournament(IDbConnection connection, Tournament tournament)
        {
            //Create a list of dynamic parameters so that they can be added to the database
            //Add the Tournament info into the list
            var list = new DynamicParameters();
            list.Add("@TournamentName", tournament.TournamentName);
            list.Add("@EntryFee", tournament.EntryFee);
            list.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

            //Run the stored procedure to insert the tournament and get the prize id
            connection.Execute("dbo.procInsertTournament", list, commandType: CommandType.StoredProcedure);
            tournament.id = list.Get<int>("@id");
        }
        /// <summary>
        /// Saves Tournament prizes info in database.
        /// </summary>
        /// <param name="connection">Conection of database.</param>
        /// <param name="tournament">Tournament whose prizes arae to be saved.</param>
        private void savePrizes(IDbConnection connection, Tournament tournament)
        {
            //Run the stored procedure to insert prizes for each tournament
            foreach (Prize prize in tournament.Prizes)
            {
                var list = new DynamicParameters();
                list.Add("@TournamentId", tournament.id);
                list.Add("@PrizeId", prize.id);
                list.Add("@ID", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                //Run the stored procedure to insert the prize into tournament prizes
                connection.Execute("dbo.procInsertTournamentPrize", list, commandType: CommandType.StoredProcedure);
            }
        }

        /// <summary>
        /// Saves tournament's teams info in database.
        /// </summary>
        /// <param name="connection">Connection of database.</param>
        /// <param name="tournament">Tournament whose teams are to be saved.</param>
        private void saveTeams(IDbConnection connection, Tournament tournament)
        {
            //Run the stored procedure to store the teams for each tournament
            foreach (Team team in tournament.Teams)
            {
                var list = new DynamicParameters();
                list.Add("@TournamentId", tournament.id);
                list.Add("@TeamId", team.id);
                list.Add("@ID", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                //Run the stored procedure to insert the team member and get the prize id
                connection.Execute("dbo.procInsertTournamentTeams", list, commandType: CommandType.StoredProcedure);
            }
        }
        /// <summary>
        /// Gets persons from the database.
        /// </summary>
        /// <returns>List of Persons.</returns>
        public List<Person> getAllPersons()
        {
            List<Person> persons;
            using (IDbConnection connection = new SqlConnection(DataConfig.getConnectionString("GCUTournaments")))
            {
                persons = connection.Query<Person>("dbo.procGetAllPersons").ToList();
            }
            return persons;
        }

        /// <summary>
        /// Gets Teams from the database.
        /// </summary>
        /// <returns>List of teams.</returns>
        public List<Team> getAllTeams()
        {
            List<Team> teams;
            using (IDbConnection connection = new SqlConnection(DataConfig.getConnectionString("GCUTournaments")))
            {
                teams = connection.Query<Team>("dbo.ProcGetAllTeams").ToList();

                //Add all the team members belonging to the specific team
                foreach(Team team in teams)
                {
                    var list = new DynamicParameters();
                    list.Add("@TeamId", team.id);

                    team.Members = connection.Query<Person>("dbo.procGetMembersByTeamId", list, commandType: CommandType.StoredProcedure).ToList();
                }

            }
            return teams;
        }

        /// <summary>
        /// Gets all the tournaments from the database.
        /// </summary>
        /// <returns>List of tournaments from the database.</returns>
        public List<Tournament> getAllTournaments()
        {
            List<Tournament> tournaments;

            //Setup the connection
            using (IDbConnection connection = new SqlConnection(DataConfig.getConnectionString("GCUTournaments")))
            {
                //Get the tournaments from the database
                tournaments = connection.Query<Tournament>("dbo.procGetAllTournaments").ToList();
                var p = new DynamicParameters();

                //Now loop through each tournament to get further info
                foreach (Tournament tournament in tournaments)
                {
                    //Initialize the dynamic parameters list
                    p = new DynamicParameters();
                    p.Add("@TournamentId", tournament.id);

                    //Get all the prizes of the tournament from the database
                    tournament.Prizes = connection.Query<Prize>("dbo.procGetPrizeByTournamentId", p, commandType: CommandType.StoredProcedure).ToList();

                    //Reinitialize the list
                    p = new DynamicParameters();
                    p.Add("@TournamentId", tournament.id);

                    //Get all the teams from the database
                    tournament.Teams = connection.Query<Team>("dbo.procGetTeamByTournamentId", p, commandType: CommandType.StoredProcedure).ToList();
                    
                    //For each team, get all the team members
                    foreach (Team team in tournament.Teams)
                    {
                        var list = new DynamicParameters();
                        list.Add("@TeamId", team.id);
                        team.Members = connection.Query<Person>("dbo.procGetMembersByTeamId", list, commandType: CommandType.StoredProcedure).ToList();
                    }

                    //Reinitialize the list
                    p = new DynamicParameters();
                    p.Add("@TournamentId", tournament.id);

                    //Get all the rounds of the tournament
                    List<Matchup> matchups = connection.Query<Matchup>("dbo.procGetMatchupsByTournamentId", p, commandType: CommandType.StoredProcedure).ToList();
                    
                    //Loop through each matchup in the rounds
                    foreach(Matchup m in matchups)
                    {
                        //Initialize a dynamic parameters list
                        var list = new DynamicParameters();
                        list.Add("@MatchupId", m.id);

                        //Get all the entries for every matchup
                        m.Entries = connection.Query<MatchupEntry>("dbo.procGetMatchupEntriesByMatchupId", list, commandType: CommandType.StoredProcedure).ToList();

                        //Ceate a list and get all teams
                        List<Team> allTeams = getAllTeams();

                        //If there has been previously a winner set for the matchup
                        if(m.WinnerId >0)
                        {
                            //Get the winner of the matchup
                            m.Winner = allTeams.Where(x => x.id == m.WinnerId).First();
                        }

                        //Now loop through each matchup entries
                        foreach(MatchupEntry entry in m.Entries )
                        {
                            //If entry has a team competing i.e it is not a bye week
                            if(entry.TeamCompetingId > 0)
                            {
                                entry.TeamCompeting = allTeams.Where(x => x.id == entry.TeamCompetingId).First();
                            }

                            //If entry is coming from a previous matchup then get the previous matchup also
                            if(entry.ParentMatchupId > 0 && entry.ParentMatchup != null)
                            {
                                entry.ParentMatchup = matchups.Where(x => x.id == entry.ParentMatchupId).First();
                            }
                        }
                    
                    }

                    //Ceate a list of rounds
                    List<Matchup> currentRound = new List<Matchup>();
                    int currentRoundNumber = 1;

                    //Loop through each matchup
                    foreach(Matchup m in matchups)
                    {
                        //If next round is reached
                        if(m.MatchupRound > currentRoundNumber)
                        {
                            //Add the round in the tournament
                            tournament.Rounds.Add(currentRound);

                            //Reinitialize the round list
                            currentRound = new List<Matchup>();
                            
                            //Increment the round number
                            currentRoundNumber++;
                        }

                        //else add the current matchup in the round
                        currentRound.Add(m);
                    }

                    //Add the last round in the tournament rounds
                    tournament.Rounds.Add(currentRound);
                }
            }
            return tournaments;
        }

        /// <summary>
        /// This method updates the information about matchups.
        /// </summary>
        /// <param name="matchup">Matchup whose info is to be updated.</param>
        public void UpdateMatchup(Matchup matchup)
        {
            //Create the connection with database
            using (IDbConnection connection = new SqlConnection(DataConfig.getConnectionString("GCUTournaments")))
            {
                //Create a list of dynamic parameters
                var list = new DynamicParameters();
                
                //If the matchup winner is announced then update the info in database
                if (matchup.Winner != null)
                {
                    list = new DynamicParameters();
                    list.Add("@id", matchup.id);
                    list.Add("@WinnerId", matchup.Winner.id);

                    connection.Execute("dbo.procUpdateMatchups", list, commandType: CommandType.StoredProcedure);
                }
                

                //Loop through each entries in the matchup
                foreach(MatchupEntry entry in matchup.Entries)
                {
                    //If the entry is not a bye week, then update its info in the database
                    if(entry.TeamCompeting != null)
                    {
                        list = new DynamicParameters();
                        list.Add("@id", entry.id);
                        list.Add("@TeamCompetingId", entry.TeamCompeting.id);
                        list.Add("@Score", entry.Score);

                        connection.Execute("dbo.procUpdateEntries", list, commandType: CommandType.StoredProcedure);
                    }
                    
                }
            }
                
        }

        /// <summary>
        /// This completes the tournament
        /// </summary>
        /// <param name="tournament"></param>
        public void CompleteTournament(Tournament tournament)
        {
            //Create the connection with database
            using (IDbConnection connection = new SqlConnection(DataConfig.getConnectionString("GCUTournaments")))
            {
                var list = new DynamicParameters();
                list.Add("@id", tournament.id);

                //Mark the tournament as inactive in the database
                connection.Execute("dbo.procCompleteTournament", list, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
