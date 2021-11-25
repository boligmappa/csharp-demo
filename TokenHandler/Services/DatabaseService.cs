using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TokenHandler.Entities;

namespace TokenHandler.Services
{
    public class DatabaseService
    {
        private List<StoredTokenModel> storedItems = new List<StoredTokenModel>();

        public async Task<StoredTokenModel> GetStoredTokens(string id)
        {
            Console.WriteLine(storedItems.Count);
            StoredTokenModel tokenObject = storedItems.Where(storedItem => storedItem.idObject.userId == id).SingleOrDefault();
            return tokenObject;
        }

        public async void SaveTokens(StoredTokenModel itemToBeStored)
        {
            var itemToBeRemoved = storedItems.SingleOrDefault(item => item.idObject.userId == itemToBeStored.idObject.userId);
            if (itemToBeRemoved != null)
            {
                storedItems.Remove(itemToBeRemoved);
            }
            Console.WriteLine(itemToBeStored);
            storedItems.Add(itemToBeStored);
            Console.WriteLine(storedItems.Count);
        }
    }
}