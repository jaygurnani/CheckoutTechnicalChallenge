using System;
using System.Linq;
using CheckoutTechnicalChallenge.Interfaces;
using CheckoutTechnicalChallenge.Models;
using CheckoutTechnicalChallenge.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CheckoutTechnicalChallenge.Tests
{
    [TestClass]
    public class RepositoryUnitTests
    {
        #region Repository Tests

        private readonly IDataAccessRepo repo;
        public RepositoryUnitTests()
        {
            repo = new FileDataAccessRepo();
        }

        [TestMethod]
        public void CanCreateBasket()
        {
            Guid basketId = repo.CreateBasket();
            Assert.IsNotNull(basketId);
            Assert.IsTrue(basketId != Guid.Empty);
        }

        [TestMethod]
        public void CanGetBasket()
        {
            Guid basketId = repo.CreateBasket();
            var result = repo.GetBasket(basketId);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CanAddToBasket()
        {
            Guid basketId = repo.CreateBasket();
            Item item = new Item
            {
                ItemName = string.Concat("JayTest", DateTime.Now.ToShortTimeString()),
                ItemQuantity = 10
            };

            var result = repo.AddToBasket(basketId, item);

            Assert.IsNotNull(result);
            Assert.IsTrue(!result.Items.Count.Equals(0));
        }

        public void CanUpdateBasket()
        {
            Guid basketId = repo.CreateBasket();
            Item item = new Item
            {
                ItemName = string.Concat("JayTest", DateTime.Now.ToShortTimeString()),
                ItemQuantity = 10
            };

            var result = repo.AddToBasket(basketId, item);
            var newItem = result.Items.First();
            newItem.ItemQuantity = 20;
            var newResult = repo.UpdateBasket(basketId, newItem);

            Assert.IsNotNull(newResult);
            var newCount = newResult.Items.First().ItemQuantity;
            Assert.IsTrue(newCount.Equals(20));
        }

        [TestMethod]
        public void CanClearBasket()
        {
            Guid basketId = repo.CreateBasket();
            Item item = new Item
            {
                ItemName = string.Concat("JayTest", DateTime.Now.ToShortTimeString()),
                ItemQuantity = 10
            };

            repo.AddToBasket(basketId, item);
            repo.ClearBasket(basketId);
            var result = repo.GetBasket(basketId);
            
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Items.Count.Equals(0));
        }

        [TestMethod]
        public void CanRemoveFromBasket()
        {
            Guid basketId = repo.CreateBasket();
            Item item = new Item
            {
                ItemName = string.Concat("JayTest", DateTime.Now.ToShortTimeString()),
                ItemQuantity = 10
            };

            var result = repo.AddToBasket(basketId, item);
            var newResult = repo.RemoveFromBasket(basketId, result.Items.First().ItemId.Value);
            
            Assert.IsNotNull(newResult);
            Assert.IsTrue(newResult.Items.Count.Equals(0));
        }

        #endregion  
    }
}
