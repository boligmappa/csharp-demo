using System;
using Microsoft.AspNetCore.Mvc;
using TokenHandler.Database;
using TokenHandler.Entities;

namespace TokenHandler.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TokenHandlerController : ControllerBase
    {
        private readonly DatabaseService _databaseService;

        public TokenHandlerController(DatabaseService databaseService)
        {
            _databaseService = databaseService;
        }


        [HttpPost("getToken")]
        public StoredTokenObject GetStoredTokens(IdObject idObject)
        {
            var storedTokenObject = _databaseService.GetStoredTokens(idObject.userId);
            return storedTokenObject;
        }

        [HttpPost("postToken")]
        public void SaveTokens(StoredTokenObject tokenObject)
        {
            Console.WriteLine("postToken");
            _databaseService.SaveTokens(tokenObject);
        }

    }
}