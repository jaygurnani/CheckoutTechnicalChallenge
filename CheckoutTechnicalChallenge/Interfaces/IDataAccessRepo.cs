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
        /// <summary>
        /// Create a Basket
        /// </summary>
        /// <returns></returns>
        Guid CreateBasket();

        /// <summary>
        /// Clear a basket by a basketId
        /// </summary>
        /// <param name="basketId"></param>
        void ClearBasket(Guid basketId);

        /// <summary>
        /// Get a basket by a basketId
        /// </summary>
        /// <param name="basketId"></param>
        /// <returns></returns>
        Basket GetBasket(Guid basketId);

        /// <summary>
        /// Add an item to the basket
        /// </summary>
        /// <param name="basketId"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        Basket AddToBasket(Guid basketId, Item item);

        /// <summary>
        /// Update an item in basket
        /// </summary>
        /// <param name="basketId"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        Basket UpdateBasket(Guid basketId, Item item);

        /// <summary>
        /// Remove an item from the basket
        /// </summary>
        /// <param name="basketId"></param>
        /// <param name="itemId"></param>
        /// <returns></returns>
        Basket RemoveFromBasket(Guid basketId, Guid itemId);
    }
}
