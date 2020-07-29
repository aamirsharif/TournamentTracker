using GCUTrackerLibrary.Data;
using GCUTrackerLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GCUTrackerLibrary
{
    public static class Logic
    {
        /// <summary>
        /// Generates rounds for the provided tournament.
        /// </summary>
        /// <param name="tournament">Tournament whose rounds are to be created.</param>
        public static void createRounds(Tournament tournament)
        {
            //Get a list of randomized teams from the tournament
            List<Team> randomizedTeams = randomizeTeams(tournament.Teams);

            //Get number of rounds and byes
            int rounds = getNumberOfRounds(randomizedTeams.Count);
            int byes = getNumberOfByes(rounds,randomizedTeams.Count);

            //Add the rounds into the tournament
            tournament.Rounds.Add(createFirstRound(byes, randomizedTeams));
            createOtherRounds(tournament, rounds);
        }
        /// <summary>
        /// Randomizes the teams of the tournament
        /// </summary>
        /// <param name="teams">List of teams to be randomized.</param>
        /// <returns>Randomized list of teams.</returns>
        private static List<Team> randomizeTeams(List<Team> teams)
        {
            return teams.OrderBy(x => Guid.NewGuid()).ToList();
        }
        /// <summary>
        /// Calculates the number of rounds for the tournament.
        /// </summary>
        /// <param name="numberOfTeams">Number of teams in the tournament.</param>
        /// <returns>Number of rounds.</returns>
        private static int getNumberOfRounds(int numberOfTeams)
        {
            //There is at least one round in the tournament
            int rounds = 1;
            int teams = 2;

            //Increment rounds until spot for all teams have been found.
            while(teams < numberOfTeams)
            {
                rounds++;
                teams *= 2;
            }
            return rounds;
        }

        /// <summary>
        /// Calculates number of byes in the tournament.
        /// </summary>
        /// <param name="rounds">Number of rounds.</param>
        /// <param name="actualTeams">Number of teams.</param>
        /// <returns></returns>
        private static int getNumberOfByes(int rounds,int actualTeams)
        {
            int byes = 0;
            int totalTeams = 1;

            //Loop from 0 to rounds
            for(int i=0;i<rounds;i++)
            {
                /*In each matchup, there are two teams competing with each other,
                 *In last round, there is only one matchup,In second last round there are two matchups
                 *so number of teams grow as 2 , 4, 6, 8 etc
                 */
                totalTeams *= 2;
            }

            //Number of byes are calculated by subtracting the actual teams from the total teams.
            byes = totalTeams - actualTeams;
            return byes;
        }

        /// <summary>
        /// Creates first round for the tournament.
        /// </summary>
        /// <param name="byes">Number of byes.</param>
        /// <param name="teams">List of teams.</param>
        /// <returns></returns>
        private static List<Matchup> createFirstRound(int byes, List<Team> teams)
        {
            //Create a list of matchups, round is a single list of matchups
            List<Matchup> round = new List<Matchup>();
            
            //Create a varaiable to store current matchup
            Matchup currentMatchup = new Matchup();

            //Loop through all the teams
            foreach(Team team in teams)
            {
                //Add the team as the matchup entry in the matchup
                currentMatchup.Entries.Add(new MatchupEntry { TeamCompeting = team });
                
                //If tournament has byes then the team in first order will be advanced to the next round
                //If two teams have been added then we need to make another matchup since we cannot put more than 2 teams in a single match.
                if(byes >0 || currentMatchup.Entries.Count>1)
                {
                    currentMatchup.MatchupRound = 1;
                    round.Add(currentMatchup);
                    currentMatchup = new Matchup();

                    if (byes > 0)
                        byes--;
                }
            }
            return round;
        }

        /// <summary>
        /// Creates all other rounds except for the first round of the tournament.
        /// </summary>
        /// <param name="tournament">Tournament whose rounds are to be created.</param>
        /// <param name="rounds">Number of rounds in the tournament.</param>
        private static void createOtherRounds(Tournament tournament, int rounds)
        {
            //Round number starts from 2 since first round has been created already.
            int roundNumber = 2;

            //Get the previous round
            List<Matchup> previousRound = tournament.Rounds[0];
            
            //Create a list of matchups for new round
            List<Matchup> currentRound = new List<Matchup>();
            
            //Create a variable to store current Matchup
            Matchup currentMatchup = new Matchup();
            
            //Loop through all rounds
            while(roundNumber <= rounds)
            {
                //Loop through all matchups from previous round
                foreach(Matchup match in previousRound)
                {
                    //Add new matchup entry into the current matchup and set its parent matchup
                    currentMatchup.Entries.Add(new MatchupEntry { ParentMatchup = match });

                    //If more than 1 entries have been added then
                    if(currentMatchup.Entries.Count > 1)
                    {
                        currentMatchup.MatchupRound = roundNumber;
                        currentRound.Add(currentMatchup);
                        currentMatchup = new Matchup();
                    }
                }

                //Add the current round to the tournament
                tournament.Rounds.Add(currentRound);
                previousRound = currentRound;

                currentRound = new List<Matchup>();
                roundNumber++;
            }
        }

        /// <summary>
        /// Updates The results of the tournament.
        /// </summary>
        /// <param name="tournament">Tournament whose results are to be updated.</param>
        public static void updateTournamentResults(Tournament tournament)
        {
            //Check current ongoing round of the tournament
            int startingRound = checkCurrentRound(tournament);

            //Create a List to keep track of matchups that need to be scored
            List<Matchup> toScore = new List<Matchup>();

            foreach(List<Matchup> round in tournament.Rounds)
            {
                foreach(Matchup match in round)
                {
                    //if we have not yet assigned winner of a matchup and either the score is not equal to zero or there is a bye in  the matchup
                    if(match.Winner == null && (match.Entries.Any(x=> x.Score != 0 ) || match.Entries.Count == 1 ))
                    {
                        toScore.Add(match);
                    }
                }
            }

            //Mark the winner teams
            MarkWinners(toScore);

            //Advance winners to next round
            AdvanceWinners(toScore,tournament);

            //Update data of all the updated matchups in the database
            toScore.ForEach(x => DataConfig.connection.UpdateMatchup(x));

            //Check the ending round after updating the matchups
            int endingRound = checkCurrentRound(tournament);

            //If round of tournament has changed then alert the users about their upcoming matches.
            if(endingRound > startingRound)
            {
                alertUsersToNewRound(tournament);
            }
        }

        /// <summary>
        /// Marks the winners of the matchups.
        /// </summary>
        /// <param name="matchups">Matchups whose winners are to be marked.</param>
        private static void MarkWinners(List<Matchup> matchups)
        {
            foreach(Matchup match in matchups)
            {
                //If there is a bye in the match
                if(match.Entries.Count == 1)
                {
                    match.Winner = match.Entries[0].TeamCompeting;
                    continue;
                }
                else
                {
                    if(match.Entries[0].Score > match.Entries[1].Score)
                    {
                        match.Winner = match.Entries[0].TeamCompeting;
                    }
                    else if(match.Entries[1].Score > match.Entries[0].Score)
                    {
                        match.Winner = match.Entries[1].TeamCompeting;
                    }
                    else
                    {
                        throw new Exception("We do not handle ties!!!");
                    }
                }
            }
        }

        /// <summary>
        /// Advances the winners to the next round.
        /// </summary>
        /// <param name="matchups">Matchups with winners.</param>
        /// <param name="tournament">Tournament undergoing.</param>
        private static void AdvanceWinners(List<Matchup> matchups,Tournament tournament)
        {
            //Loop through all matchups
            foreach(Matchup matchup in matchups)
            {
                //Loop through all tournament rounds
                foreach (List<Matchup> round in tournament.Rounds)
                {
                    //Loop through all matchups of each round
                    foreach (Matchup m in round)
                    {
                        //Loop through all entries of each matchup
                        foreach (MatchupEntry en in m.Entries)
                        {
                            //If the entry's parent matchup exists i.e. the entry is not from the winner matchups
                            if (en.ParentMatchup != null)
                            {
                                //If the entries parent matchup id matches the current matchup id, then the matchups winner will
                                //compete with this team.
                                if (en.ParentMatchup.id == matchup.id)
                                {
                                    en.TeamCompeting = matchup.Winner;

                                    //Update the matchups in the database.
                                    DataConfig.connection.UpdateMatchup(m);
                                }
                            }

                        }
                    }
                }
            }
        }

        /// <summary>
        /// Checks the current ongoing round of the tournament
        /// </summary>
        /// <param name="tournament">Tournament whose current round is to be checked.</param>
        /// <returns></returns>
        private static int checkCurrentRound(Tournament tournament)
        {
            int roundNumber = 1;
            foreach (List<Matchup> round in tournament.Rounds)
            {
                //If all the matchups in the round have winners then.
                if (round.All(x => x.Winner != null))
                {
                    roundNumber++;
                }
                else
                {
                    return roundNumber;
                }
            }

            //If all the winners are announced then it means tournament has been completed.
            CompleteTournament(tournament);
            return roundNumber - 1;
        }

        /// <summary>
        /// Alerts users about new rounds.
        /// </summary>
        /// <param name="tournament">Tournament whose users are to be notified.</param>
        public static void alertUsersToNewRound(Tournament tournament)
        {
            //Get the current round
            int currentRound = checkCurrentRound(tournament);
            
            //Get the list of matchup for the current round
            List<Matchup> round = tournament.Rounds.Where(x => x.First().MatchupRound == currentRound).First();


            foreach(Matchup matchup in round)
            {
                foreach(MatchupEntry entry in matchup.Entries)
                {
                    //If the team competing exists for the entry i.e. there is no bye entry.
                    if(entry.TeamCompeting != null)
                    {
                        foreach (Person member in entry.TeamCompeting.Members)
                        {
                            alertMemberToNewRound(tournament.TournamentName, member, entry.TeamCompeting.TeamName, matchup.Entries.Where(x => x.TeamCompeting != entry.TeamCompeting).FirstOrDefault());
                        }
                    }
                    
                }
            }
        }

        /// <summary>
        /// This method alerts member about there new matchup.
        /// </summary>
        /// <param name="tournamentName">Name of ongoing tournament.</param>
        /// <param name="member">Member to be notified.</param>
        /// <param name="teamName">Name of member's team.</param>
        /// <param name="competitor">Competitor of the member.</param>
        private static void alertMemberToNewRound(string tournamentName,Person member, string teamName, MatchupEntry competitor)
        {
            //If member has no email
            if(member.Email.Length ==0)
            {
                return;
            }


            string to = "";
            string subject = "";

            StringBuilder body = new StringBuilder();

            if(competitor != null && competitor.TeamCompeting != null)
            {
                subject = $"New Upcoming match with {competitor.TeamCompeting.TeamName}";

                body.AppendLine("<h1>You have a new Match!!</h1>");
                body.Append("<br><strong>Tournament: </strong>");
                body.Append(tournamentName);
                body.Append("<br><strong>Competitor: </strong>");
                body.Append(competitor.TeamCompeting.TeamName);
                body.AppendLine("<br><br>Good Luck with your match!!");
                body.AppendLine("<br><br>Regards, <br>GCU Tournament Tracker");
            }
            else
            {
                subject = "No match this week.";

                body.AppendLine("<h1>You have no match!!</h1>");
                body.Append("<br><strong>Tournament: </strong>");
                body.Append(tournamentName);
                body.AppendLine("<br><br>Enjoy!!");
                body.AppendLine("<br><br>Regards, <br>GCU Tournament Tracker");
            }

            to = member.Email;

            //Send the email
            Email.sendEmail(to, subject, body.ToString());
        }

        /// <summary>
        /// This method is called when all the winners of tournament have been announced.
        /// </summary>
        /// <param name="tournament">Tournament to be completed.</param>
        private static void CompleteTournament(Tournament tournament)
        {
            //Mark the tournament as inactive in the database
            DataConfig.connection.CompleteTournament(tournament);

            //Get the team winner and runner up (2nd team)
            Team winners = tournament.Rounds.Last().First().Winner;
            Team runnerUp = tournament.Rounds.Last().First().Entries.Where(x => x.TeamCompeting != winners).First().TeamCompeting;

            double winnerPrize = 0;
            double runnerUpPrize = 0;

            //If tournament has prizes
            if(tournament.Prizes.Count > 0)
            {
                double totalIncome = tournament.Teams.Count * tournament.EntryFee;
                Prize firstPrize = tournament.Prizes.Where(x => x.PlaceNumber == 1).FirstOrDefault();
                Prize secondPrize = tournament.Prizes.Where(x => x.PlaceNumber == 2).FirstOrDefault();

                if(firstPrize != null)
                {
                    winnerPrize = calculatePrize(firstPrize, totalIncome);
                }
                
                if(secondPrize != null)
                {
                    runnerUpPrize = calculatePrize(secondPrize, totalIncome);
                }
            }

            //Send Email
            string subject = "";

            StringBuilder body = new StringBuilder();
            subject = $"Team {winners.TeamName} has won {tournament.TournamentName}.";

            body.AppendLine("<h1>We have a WINNER!</h1>");
            body.Append("<br>");
            body.AppendLine($"<strong>Tournament Name: {tournament.TournamentName}");
            body.Append("<br>");

            if(winnerPrize >0)
            {
                body.AppendLine($"<p>{winners.TeamName} will recieve: {winnerPrize} Rupees.</p>");
            }

            if(runnerUpPrize>0)
            {
                body.AppendLine($"<p>{runnerUp.TeamName} will recieve: {runnerUpPrize} Rupees.</p>");
            }
            body.AppendLine("<br>Thank You everyone for such an amazing Tournament.!!");
            body.AppendLine("<br>Regards, <br>GCU Tournament Tracker");

            List<string> bcc = new List<string>();
            foreach(Team t in tournament.Teams)
            {
                foreach(Person p in t.Members)
                {
                    if(p.Email.Length>0)
                    {
                        bcc.Add(p.Email);
                    }
                }
            }
            Email.sendEmail(new List<string> { },bcc, subject, body.ToString());
            tournament.Complete();
        }

        /// <summary>
        /// Calculates the prize to be given to team.
        /// </summary>
        /// <param name="prize">Prize to be given</param>
        /// <param name="totalIncome">Total income from the tournament.</param>
        /// <returns></returns>
        private static double calculatePrize(Prize prize,double totalIncome)
        {
            double amount = 0;
            if(prize.Amount >0)
            {
                amount = prize.Amount;
            }
            else
            {
                amount = totalIncome * (prize.Percentage / 100);
            }

            return amount;
        }
    }
}
