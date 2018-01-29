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
            var request = new GetBasket(basketId);
            var response = request.Get();
            if (string.IsNullOrWhiteSpace(response))
            {
                return null;
            }
            return JsonConvert.DeserializeObject<Basket>(response);
        }

        public Basket AddToBasket(Guid basketId, Item item)
        {
            var request = new AddToBasket(basketId, item);
            var response = request.Put();
            if (string.IsNullOrWhiteSpace(response))
            {
                return null;
            }
            return JsonConvert.DeserializeObject<Basket>(response);
        }

        public Basket UpdateBasket(Guid basketId, Item item)
        {
            var request = new UpdateBasket(basketId, item);
            var response = request.Patch();
            if (string.IsNullOrWhiteSpace(response))
            {
                return null;
            }
            return JsonConvert.DeserializeObject<Basket>(response);
        }

        public void ClearBasket(Guid basketId)
        {
            var request = new ClearBasket(basketId);
            var response = request.Delete();
        }

        public Basket RemoveFromBasket(Guid basketId, Guid itemId)
        {
            var request = new ClearItem(basketId, itemId);
            var response = request.Delete();
            if (string.IsNullOrWhiteSpace(response))
            {
                return null;
            }
            return JsonConvert.DeserializeObject<Basket>(response);
        }
    }
}
