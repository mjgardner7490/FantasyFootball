using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using YahooSports.Api;
using YahooSports.Api.Exceptions;
using YahooSports.Api.Sports.Models;
using YahooSports.OAuthLib.Core;

namespace YahooAPI
{
    public class SportsProviderService : ISportsProviderService
    {
        private static SportsProvider Client;
        private static AccessToken Token;

        // Add this to secrets file
        private static readonly string CONSUMER_KEY = "dj0yJmk9RTdwa0JPdm9yd2N1JmQ9WVdrOVZIVkxRMVJETXpZbWNHbzlNQS0tJnM9Y29uc3VtZXJzZWNyZXQmeD03Yg--";
        private static readonly string CONSUMER_SECRET = "b4501ca7d9301f9173c1b6be607f63896e34a2ff";
        private const string TOKEN_FILE = "token3";
        private static readonly IsolatedStorageFile Storage = IsolatedStorageFile.GetUserStoreForAssembly();

        public SportsProviderService()
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

        public FantasyContent GetLeagueInfo()
        {
            try
            {
                FantasyContent content = Client.ExecuteRequest<FantasyContent>(@"http://fantasysports.yahooapis.com/fantasy/v2/league/359.l.247388/scoreboard;week=2");
                return content;
            }
            catch (SportsApiException)
            {
                var token = Client.RefreshToken();
                FantasyContent content = Client.ExecuteRequest<FantasyContent>(@"http://fantasysports.yahooapis.com/fantasy/v2/league/359.l.247388/scoreboard;week=2");
                return content;
            }
        }
    }
}
