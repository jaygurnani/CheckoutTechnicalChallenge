using CheckoutTechnicalChallenge.SDK.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutTechnicalChallenge.SDK.Requests
{
    public class UpdateBasket : BaseRequest
    {
        private Guid _basketId;
        private Item _item;

        public UpdateBasket(Guid basketId, Item item)
        {
            _basketId = basketId;
            _item = item;
        }

        public override string requestUrl { get => string.Concat(base.baseUrl, "api/v1/", _basketId); }

        public override string jsonString { get => JsonConvert.SerializeObject(_item); }
    }
}
