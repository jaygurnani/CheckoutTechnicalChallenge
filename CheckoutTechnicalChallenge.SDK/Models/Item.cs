using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutTechnicalChallenge.SDK.Models
{
    public class Item
    {
        public Guid? ItemId { get; set; }
        public string ItemName { get; set; }
        public int ItemQuantity { get; set; }
    }
}
