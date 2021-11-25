using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TokenHandler.Entities;

namespace TokenHandler.Services
{
    public class RequestService
    {
        private static readonly HttpClient client = new HttpClient();


        public async Task<TokenResponseModel> ExchangeAuthCodeForTokens(AuthCodeObjectModel authCodeObject)
        {
            var urlParameters = new List<KeyValuePair<string, string>>();
            urlParameters.Add(new KeyValuePair<string, string>("client_id", "alpha-client"));
            urlParameters.Add(new KeyValuePair<string, string>("client_secret", "661b5b3f-4f3a-4554-bdd6-b77a30f57767"));
            urlParameters.Add(new KeyValuePair<string, string>("grant_type", "authorization_code"));
            urlParameters.Add(new KeyValuePair<string, string>("scope", authCodeObject.scope));
            urlParameters.Add(new KeyValuePair<string, string>("code", authCodeObject.authCode));
            urlParameters.Add(new KeyValuePair<string, string>("code_verifier", authCodeObject.codeVerifier));
            urlParameters.Add(new KeyValuePair<string, string>("redirect_uri", "http://localhost:8080/boligmappa-redirect"));

            var request = new HttpRequestMessage(HttpMethod.Post, "https://testauth.boligmappa.no/auth/realms/professional-realm-staging/protocol/openid-connect/token") { Content = new FormUrlEncodedContent(urlParameters) }; //The Url here should not be hard coded and depend on if the environment is prod or dev

            var res = await client.SendAsync(request);

            Console.WriteLine(res.Content.ToString());

            var tokenResponse = await res.Content.ReadAsAsync<TokenResponseModel>();
            Console.WriteLine(tokenResponse);

            return tokenResponse;

            // return new TokenResponseModel();

        }

    }
}