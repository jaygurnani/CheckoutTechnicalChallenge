using CheckoutTechnicalChallenge.SDK.Models;
using CheckoutTechnicalChallenge.SDK.Requests;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutTechnicalChallenge.SDK
{
    public class CheckoutTechnicalChallengeSDK
    {
        public Guid CreateBasket()
        {
            var request = new CreateBasket();
            var response = request.Post();
            if (string.IsNullOrWhiteSpace(response))
            {
                throw new ApplicationException("Internal server error");
            }
            var r = JsonConvert.DeserializeObject<string>(response);
            return Guid.Parse(r);
        }
        
        public Basket GetBasket(Guid basketId)
        {
            var request = new GetBasketRequest(basketId);
            var response = request.Get();
            if (string.IsNullOrWhiteSpace(response))
            {
                return null;
            }
            return JsonConvert.DeserializeObject<Basket>(response);
        }
    }
}
