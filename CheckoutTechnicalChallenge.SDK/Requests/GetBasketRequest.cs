using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutTechnicalChallenge.SDK.Requests
{
    public class GetBasket : BaseRequest
    {
        private Guid _basketId;

        public GetBasket(Guid basketId)
        {
            _basketId = basketId;
        }

        public override string requestUrl { get => string.Concat(base.baseUrl, "api/v1/", _basketId); }
        public override string jsonString { get => JsonConvert.SerializeObject(_basketId); }
    }
}
