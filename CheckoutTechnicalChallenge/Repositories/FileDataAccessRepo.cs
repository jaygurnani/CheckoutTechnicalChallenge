using CheckoutTechnicalChallenge.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CheckoutTechnicalChallenge.Models;
using Newtonsoft.Json;
using System.IO;

namespace CheckoutTechnicalChallenge.Repositories
{
    public class FileDataAccessRepo : IDataAccessRepo
    {
        private const string DatabaseFileName = "C:\\Database.json";

        // Main database
        private static IDictionary<Guid, Basket> _database;

        public FileDataAccessRepo()
        {
            if (_database == null && !File.Exists(DatabaseFileName))
            {
                _database = new Dictionary<Guid, Basket>();
                SaveDatabase();
            }
            else
            {
                string dictionaryText = File.ReadAllText(DatabaseFileName);
                _database = JsonConvert.DeserializeObject<Dictionary<Guid, Basket>>(dictionaryText);
            }
        }

        public void AddOrUpdateBasket(Guid basketId, Item item)
        {
            Basket b = GetBasket(basketId);
            if (b == null)
            {
                throw new ApplicationException("Basket Id is invalid");
            }

            b.Items.RemoveAll(f => f.ItemId.Equals(item.ItemId));
            b.Items.Add(item);
            SaveDatabase()
        }

        public void ClearBasket(Guid basketId)
        {
            Basket b = GetBasket(basketId);
            if (b == null)
            {
                throw new ApplicationException("Basket Id is invalid");
            }

            _database.Remove(basketId);
            SaveDatabase();
        }

        public Guid CreateBasket()
        {
            Guid g = Guid.NewGuid();
            Basket b = new Basket();
            _database.Add(g, b);
            SaveDatabase();
            return g;
        }

        public void RemoveFromBasket(Guid basketId, Guid itemId)
        {
            Basket b = GetBasket(basketId);
            if (b == null)
            {
                throw new ApplicationException("Basket Id is invalid");
            }

            b.Items.RemoveAll(f => f.ItemId.Equals(itemId));
            SaveDatabase();
        }

        /// <summary>
        /// Save the database
        /// </summary>
        public void SaveDatabase()
        {
            var db = JsonConvert.SerializeObject(_database, Formatting.Indented);
            File.WriteAllText(DatabaseFileName, db);
        }

        /// <summary>
        /// Return Basket
        /// </summary>
        /// <param name="g"></param>
        /// <returns></returns>
        public Basket GetBasket(Guid g)
        {
            if (!_database.Keys.Contains(g))
            {
                return null;
            }

            return _database[g];
        }
    }
}