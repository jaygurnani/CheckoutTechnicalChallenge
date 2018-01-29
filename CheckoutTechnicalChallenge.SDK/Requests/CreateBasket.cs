using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutTechnicalChallenge.SDK.Requests
{
    public class CreateBasket : BaseRequest
    {
        public CreateBasket()
        {

        }

        public override string requestUrl { get => string.Concat(base.baseUrl, "api/v1/"); }

        public override string jsonString { get => string.Empty; }
    }
}
