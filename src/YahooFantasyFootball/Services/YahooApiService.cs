using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using YahooFantasyFootball.ViewModels;
using YahooSports.Api;
using YahooSports.Api.Exceptions;
using YahooSports.Api.Sports.Models;
using YahooSports.OAuthLib.Core;

namespace YahooFantasyFootball.Services
{
    public class YahooApiService : IYahooApiService
    {
        private static SportsProvider Client;
        private static AccessToken Token;

        // Add this to secrets file
        private static readonly string CONSUMER_KEY = "dj0yJmk9RTdwa0JPdm9yd2N1JmQ9WVdrOVZIVkxRMVJETXpZbWNHbzlNQS0tJnM9Y29uc3VtZXJzZWNyZXQmeD03Yg--";
        private static readonly string CONSUMER_SECRET = "b4501ca7d9301f9173c1b6be607f63896e34a2ff";

        public YahooApiService()
        {
            var nameValueCollection = new NameValueCollection();
            nameValueCollection.Add("oauth_session_handle", "AEq.oFgczmkY.JCTRgw.QyWgp9lGHMTyB_j9JQJA3gV__pWdZyI-");
            nameValueCollection.Add("oauth_expires_in", "3600");
            nameValueCollection.Add("oauth_authorization_expires_in", "659667716");
            nameValueCollection.Add("xoauth_yahoo_guid", "JUGBTYOWS5TV3CMVFBHUWYZR5U");

            Token = new AccessToken();
            Token.Token = "A=026in7zpoCwBeNeFa_aL62_T2VuP6cHOUMk9xvSpau2mJvDA.csfLrRiiakmVqWHzZ_NdBqWG4rz7_2yd1CDLXvTOu9CXkpbfSpYEL4F3sDLCWsDlCIPpVl8WGmug27WkI7mczgWN68UJPJs52ToiA.Njgah8Is9GBzKncVec7G557KDh07tilu8S9Yq9TO_EnSfwtqIpw6scNozpfmIVHZ3HQnV5NdWB9Qj3SjCIEuNUut6wqYqsAvK4Ay8S7SqfEMdi4CXW0Q.xk0YmBdwIqAmvryaQoX8YAJP4MiHdzGVKfqMxb_fUqeJFY7BjglZdMh2dVyvPPpT9dhYEWBVL1TGB6LMPmd.kczuV8e8ykHgCDeclZC86KdveK8PDfDjiILNIMyZjCwv25kM5HcPdsfP9xGof8X2kX6MjfIMpBAhotSe2_tXOm8rdemEDLi.SQvD2j7cC4t..xkn9tt4PWGBXIinzcBJQDxSu9rBfpUy3lizX6qIwLzhkkGxe7VNnaFOfxwy6Ct.JtGoss..ytAz87weWqQ9Y0O4mvd6jI0TytqSPSYULlxP7gMGrzJGf0Qlimia2azMfrUtorLloJstQnDB0Tj6QS8YiaFo1Up4f1Wom5_RLrvKr9k97_nGxXy8VMLwhwrvfGGbenVYxT8eJwWWnJRQ6fDhpPOyQsYkJ2NAyga7zrux5GArip1kGKZxs4UIn7HaXhzRY44q0k7ygIxIr3a.bpomZc7YVEbvu6PdpuH92IHkLu5mvEnLtTZddCDUl_GdEtHTPWYWWVoYqbcjO33q4kp9pMWE6Q--";
            Token.TokenSecret = "17fc1153a844f36815e5fe4e99234cb12950d2fd";
            Token.AddtionalProperties = nameValueCollection;

            Client = new SportsProvider("", CONSUMER_KEY, CONSUMER_SECRET, Token);
        }

        public StandingsVM GetLeagueStandings()
        {
            FantasyContent content;
            StandingsVM standingsVM = new StandingsVM();

            try
            {
                content = Client.ExecuteRequest<FantasyContent>(@"http://fantasysports.yahooapis.com/fantasy/v2/league/359.l.247388/standings");
            }
            catch (SportsApiException)
            {
                var token = Client.RefreshToken();
                content = Client.ExecuteRequest<FantasyContent>(@"http://fantasysports.yahooapis.com/fantasy/v2/league/359.l.247388/standings");
            }

            standingsVM.leagueName = content.League.Name;
            List<TeamStanding> teamStandings = new List<TeamStanding>();
            int placement = 1;

            foreach (var team in content?.League.LeagueStandings.Teams)
            {
                TeamStanding teamStanding = new TeamStanding()
                {
                    TeamManager = team.Managers.Single().Nickname,
                    Placement = placement,
                    NumberOfMoves = team.NumberOfMoves,
                    logoUrl = team.Logos.Single().LogoUrl
                };

                placement++;
                teamStandings.Add(teamStanding);
            }

            standingsVM.TeamStandings = teamStandings;
            return standingsVM;
        }

        public WeatherToolVM GetTeamRoster(string teamId, int gameWeekId)
        {
            FantasyContent content;
            WeatherToolVM weatherToolVM = new WeatherToolVM();

            string url = string.Format(@"http://fantasysports.yahooapis.com/fantasy/v2/team/{0}/roster;week={1}", teamId, gameWeekId);

            try
            {
                content = Client.ExecuteRequest<FantasyContent>(url);
                //content = Client.ExecuteRequest<FantasyContent>(@"http://fantasysports.yahooapis.com/fantasy/v2/team/359.l.247388.t.9/roster;week=2");
            }
            catch (SportsApiException)
            {
                var token = Client.RefreshToken();
                content = Client.ExecuteRequest<FantasyContent>(url);
            }

            List<NflPlayer> roster = new List<NflPlayer>();

            foreach (var player in content?.Team.TeamRoster.Players)
            {
                NflPlayer nflPlayer = new NflPlayer()
                {
                    NflTeam = player.EditorialTeamFullName,
                    PlayerName = player.Name.Full,
                    PlayerPosition = player.DisplayPosition,
                    PlayerImageUrl = player.ImageUrl             
                };

                roster.Add(nflPlayer);
            }

            weatherToolVM.TeamRoster = roster;
            return weatherToolVM;
        }
    }
}
