using System;
using System.Collections.Generic;
using System.Linq;
using TokenHandler.Entities;

namespace TokenHandler.Database
{
    public class DatabaseService
    {
        private List<StoredTokenObject> storedItems = new List<StoredTokenObject>();

        public StoredTokenObject GetStoredTokens(string id)
        {
            Console.WriteLine(storedItems.Count);
            StoredTokenObject tokenObject = storedItems.Where(storedItem => storedItem.idObject.userId == id).SingleOrDefault();
            return tokenObject;
        }

        public void SaveTokens(StoredTokenObject itemToBeStored)
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