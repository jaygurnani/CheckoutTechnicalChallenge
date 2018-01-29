using CheckoutTechnicalChallenge.SDK.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutTechnicalChallenge.SDK.Requests
{
    public class AddToBasket : BaseRequest
    {
        private Item _item;

        public AddToBasket(Item item)
        {
            _item = item;
        }

        public override string requestUrl { get => }

        public override string jsonString { get => JsonConvert.SerializeObject(_item); }
    }
}
