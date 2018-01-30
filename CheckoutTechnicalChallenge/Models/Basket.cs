using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckoutTechnicalChallenge.Models
{
    public class Basket
    {
        /// <summary>
        /// List of items
        /// </summary>
        public List<Item> Items { get; set; }
    }
}