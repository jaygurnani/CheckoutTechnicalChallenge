using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutTechnicalChallenge.SDK.Requests
{
    class ClearBasket : BaseRequest
    {
        private Guid _basketId;

        public ClearBasket(Guid basketId)
        {
            _basketId = basketId;
        }

        public override string requestUrl { get => string.Concat(base.baseUrl, "api/v1/", _basketId); }

        public override string jsonString { get => string.Empty; }
    }
}
