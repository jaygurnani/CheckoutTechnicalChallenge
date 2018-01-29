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

        public Basket AddToBasket(Guid basketId, Item item)
        {
            var b = GetValidBasketAndItem(basketId, item);
            item.ItemId = Guid.NewGuid();

            b.Items.RemoveAll(f => f.ItemId.Equals(item.ItemId));
            b.Items.Add(item);
            SaveDatabase();

            return b;
        }

        public Basket UpdateBasket(Guid basketId, Item item)
        {
            var b = GetValidBasketAndItem(basketId, item);

            b.Items.RemoveAll(f => f.ItemId.Equals(item.ItemId));
            b.Items.Add(item);
            SaveDatabase();

            return b;
        }

        public void ClearBasket(Guid basketId)
        {
            Basket b = GetBasket(basketId);
            if (b == null)
            {
                throw new ApplicationException("Basket Id is invalid");
            }

            b.Items = new List<Item>();
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

        public Basket RemoveFromBasket(Guid basketId, Guid itemId)
        {
            Basket b = GetBasket(basketId);
            if (b == null)
            {
                throw new ApplicationException("Basket Id is invalid");
            }

            b.Items.RemoveAll(f => f.ItemId.Equals(itemId));
            SaveDatabase();

            return b;
        }

        /// <summary>
        /// Save the database
        /// </summary>
        private void SaveDatabase()
        {
            var db = JsonConvert.SerializeObject(_database, Formatting.Indented);
            File.WriteAllText(DatabaseFileName, db);
        }

        /// <summary>
        /// Return Basket
        /// </summary>
        /// <param name="basketId"></param>
        /// <returns></returns>
        public Basket GetBasket(Guid basketId)
        {
            if (!_database.Keys.Contains(basketId))
            {
                return null;
            }

            return _database[basketId];
        }

        private Basket GetValidBasketAndItem(Guid basketId, Item item)
        {
            if (string.IsNullOrWhiteSpace(item.ItemName) || item.ItemQuantity.Equals(0))
            {
                throw new ApplicationException("item is not valid");
            }

            Basket b = GetBasket(basketId);
            if (b == null)
            {
                throw new ApplicationException("Basket does not exist");
            }
            if (b.Items == null)
            {
                b.Items = new List<Item>();
            }

            return b;
        }
    }
}