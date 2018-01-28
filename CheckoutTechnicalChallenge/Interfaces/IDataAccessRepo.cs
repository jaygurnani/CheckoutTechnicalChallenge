using CheckoutTechnicalChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutTechnicalChallenge.Interfaces
{
    public interface IDataAccessRepo
    {
        Guid CreateBasket();

        void ClearBasket(Guid basketId);

        Basket AddOrUpdateBasket(Guid basketId, Item item);

        Basket RemoveFromBasket(Guid basketId, Guid itemId);
    }
}
