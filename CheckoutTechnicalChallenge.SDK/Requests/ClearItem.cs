using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutTechnicalChallenge.SDK.Requests
{
    public class ClearItem : BaseRequest
    {
        private Guid _basketId;
        private Guid _itemId;

        public ClearItem(Guid basketId, Guid itemId)
        {
            _basketId = basketId;
            _itemId = itemId;
        }

        public override string requestUrl { get => string.Concat(base.baseUrl, "api/v1/", _basketId, "/", _itemId); }

        public override string jsonString { get => string.Empty; }
    }
}
