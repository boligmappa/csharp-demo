using System;
using Microsoft.AspNetCore.Mvc;
using TokenHandler.Services;
using TokenHandler.Entities;
using System.Threading.Tasks;

namespace TokenHandler.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TokenProviderController : ControllerBase
    {
        private readonly DatabaseService _databaseService;
        private readonly RequestService _requestService;

        public TokenProviderController(DatabaseService databaseService, RequestService requestService)
        {
            _databaseService = databaseService;
            _requestService = requestService;
        }


        [HttpPost]
        [Route("Retrieve")]
        public async Task<AccessTokenModel> GetStoredTokens(IdObjectModel idObject)
        {
            var storedTokenObject = await _databaseService.GetStoredTokens(idObject.userId);


            var accessToken = new AccessTokenModel()
            {
                accessToken = storedTokenObject.accessToken
            };
            return accessToken;
        }

        [HttpPost]
        [Route("Exchange")]
        public async Task<AccessTokenModel> ExhangeAuthCodeForTokensAsync(AuthCodeObjectModel authCodeObject)
        {
            Console.WriteLine("exchangeToken");
            Console.WriteLine(authCodeObject);

            var tokenResponse = await _requestService.ExchangeAuthCodeForTokens(authCodeObject);

            var tokenObjectToBeStored = new StoredTokenModel()
            {
                idObject = authCodeObject.idObject,
                accessToken = tokenResponse.access_token,
                refreshToken = tokenResponse.refresh_token
            };

            _databaseService.SaveTokens(tokenObjectToBeStored);

            var accessToken = new AccessTokenModel()
            {
                accessToken = tokenResponse.access_token
            };

            return accessToken;
        }

    }
}