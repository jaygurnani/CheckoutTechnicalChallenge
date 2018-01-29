using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CheckoutTechnicalChallenge.SDK;

namespace CheckoutTechnicalChallenge.Tests
{
    [TestClass]
    public class SDKUnitTests
    {
        private CheckoutTechnicalChallengeSDK sdk;
        public SDKUnitTests()
        {
            sdk = new CheckoutTechnicalChallengeSDK();
        }

        [TestMethod]
        public void SDKCanCreateBasket()
        {
            var result = sdk.CreateBasket();
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void SDKCanGetBasket()
        {
            var newBasket = sdk.CreateBasket();
            var result = sdk.GetBasket(newBasket);
            Assert.IsNotNull(result);
        }
    }
}
