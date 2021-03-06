﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CheckoutTechnicalChallenge.SDK;
using CheckoutTechnicalChallenge.SDK.Models;
using System.Linq;
using System.Net;

namespace CheckoutTechnicalChallenge.Tests
{
    [TestClass]
    public class SDKUnitTests
    {
        #region Success SDK Unit Tests

        private CheckoutTechnicalChallengeSDK sdk;
        public SDKUnitTests()
        {
            sdk = new CheckoutTechnicalChallengeSDK();
        }

        [TestMethod]
        public void SDKCanCreateBasket()
        {
            var basketId = sdk.CreateBasket();
            Assert.IsNotNull(basketId);
        }

        [TestMethod]
        public void SDKCanGetBasket()
        {
            var basketId = sdk.CreateBasket();
            var result = sdk.GetBasket(basketId);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void SDKCanAddToBasket()
        {
            var basketId = sdk.CreateBasket();
            Item item = new Item
            {
                ItemName = string.Concat("JayTest", DateTime.Now.ToShortTimeString()),
                ItemQuantity = 10
            };

            var result = sdk.AddToBasket(basketId, item);
            Assert.IsNotNull(result);
            Assert.IsTrue(!result.Items.Count.Equals(0));
        }

        [TestMethod]
        public void SDKCanUpdateBasket()
        {
            var basketId = sdk.CreateBasket();
            Item item = new Item
            {
                ItemName = string.Concat("JayTest", DateTime.Now.ToShortTimeString()),
                ItemQuantity = 10
            };

            var result = sdk.AddToBasket(basketId, item);
            var newItem = result.Items.First();
            newItem.ItemQuantity = 20;
            var newResult = sdk.UpdateBasket(basketId, newItem);

            Assert.IsNotNull(newResult);
            var newCount = newResult.Items.First().ItemQuantity;
            Assert.IsTrue(newCount.Equals(20));
        }

        [TestMethod]
        public void SDKCanClearBasket()
        {
            Guid basketId = sdk.CreateBasket();
            Item item = new Item
            {
                ItemName = string.Concat("JayTest", DateTime.Now.ToShortTimeString()),
                ItemQuantity = 10
            };

            sdk.AddToBasket(basketId, item);
            sdk.ClearBasket(basketId);
            var result = sdk.GetBasket(basketId);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Items.Count.Equals(0));
        }

        [TestMethod]
        public void SDKCanRemoveFromBasketFailure()
        {
            Guid basketId = sdk.CreateBasket();
            Item item = new Item
            {
                ItemName = string.Concat("JayTest", DateTime.Now.ToShortTimeString()),
                ItemQuantity = 10
            };
            try
            {
                var result = sdk.AddToBasket(Guid.Empty, item);
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsNotNull(ex);
            }
        }
        #endregion

        #region Failure SDK Unit Test
        public void SDKCanAddToBasketFailure()
        {
            var basketId = sdk.CreateBasket();
            Item item = new Item
            {
                ItemName = string.Concat("JayTest", DateTime.Now.ToShortTimeString()),
                ItemQuantity = -1
            };
            try
            {
                var result = sdk.AddToBasket(basketId, item);
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsNotNull(ex);
            }   
        }
        #endregion

    }
}
