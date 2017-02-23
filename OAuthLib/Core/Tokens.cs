using System.Collections.Specialized;
using System.Web;
using System;

namespace YahooSports.OAuthLib.Core {
    [Serializable]
    public class TokenBase {
        public string Token { get; set; }
        public string TokenSecret { get; set; }
        public NameValueCollection AddtionalProperties { get; set; }

        public TokenBase() {
            AddtionalProperties = new NameValueCollection();
        }

        public void Init(string tokenResponse) {
            string[] parts = tokenResponse.Split('&');
            foreach (var part in parts) {
                var nameValue = part.Split('=');
                if (nameValue.Length == 2) {
                    if (nameValue[0] == "oauth_token")
                        Token = HttpUtility.UrlDecode(nameValue[1]);
                    else if (nameValue[0] == "oauth_token_secret")
                        TokenSecret = HttpUtility.UrlDecode(nameValue[1]);
                    else
                        AddtionalProperties.Add(nameValue[0], HttpUtility.UrlDecode(nameValue[1]));
                }
            }
        }
    }

    public class RequestToken : TokenBase {
        public bool CallbackConfirmed { get; set; }
    }

    [Serializable]
    public class AccessToken : TokenBase {
        public AccessToken() {
        }
    }
   
}