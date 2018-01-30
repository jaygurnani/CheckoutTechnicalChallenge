using CheckoutTechnicalChallenge.Interfaces;
using CheckoutTechnicalChallenge.Models;
using CheckoutTechnicalChallenge.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CheckoutTechnicalChallenge.Controllers
{
    /// <summary>
    /// BasketController
    /// </summary>
    public class BasketController : ApiController
    {
        readonly IDataAccessRepo repo;

        /// <summary>
        /// Constructor
        /// </summary>
        public BasketController()
        {
            repo = new FileDataAccessRepo();
        }

        /// <summary>
        /// Create Basket
        /// </summary>
        /// <returns></returns>
        [Route("api/v1")]
        [HttpPost]
        public IHttpActionResult CreateBasket()
        {
            var result = repo.CreateBasket();
            return Ok(result);
        }

        /// <summary>
        /// Get a basket by basketId
        /// </summary>
        /// <param name="basketId"></param>
        /// <returns></returns>
        [Route("api/v1/{basketId:Guid}")]
        [HttpGet]
        public IHttpActionResult GetBasket(Guid basketId)
        {
            if (basketId == Guid.Empty)
            {
                return BadRequest("basketId is not valid");
            }

            var currentBasket = repo.GetBasket(basketId);
            return Ok(currentBasket);
        }

        /// <summary>
        /// Clear a basket by basketId
        /// </summary>
        /// <param name="basketId"></param>
        /// <returns></returns>
        [Route("api/v1/{basketId:Guid}")]
        [HttpDelete]
        public IHttpActionResult ClearBasket(Guid basketId)
        {
            if (basketId == Guid.Empty)
            {
                return BadRequest("basketId is not valid");
            }

            repo.ClearBasket(basketId);
            return Ok();
        }

        /// <summary>
        /// Add an item to basket 
        /// </summary>
        /// <param name="basketId"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        [Route("api/v1/{basketId:Guid}")]
        [HttpPut]
        public IHttpActionResult AddToBasket(Guid basketId, [FromBody]Item item)
        {
            if (basketId == Guid.Empty)
            {
                return BadRequest("basketId is not valid");
            }

            if (item == null)
            {
                return BadRequest("item is not valid");
            }
            if (item.ItemId.HasValue)
            {
                return BadRequest("Item has an Id, please update the item instead");
            }

            var currentBasket = repo.AddToBasket(basketId, item);
            return Ok(currentBasket);
        }

        /// <summary>
        /// Update a basket with an item
        /// </summary>
        /// <param name="basketId"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        [Route("api/v1/{basketId:Guid}")]
        [HttpPatch]
        public IHttpActionResult UpdateBasket(Guid basketId, [FromBody]Item item)
        {
            if (basketId == Guid.Empty)
            {
                return BadRequest("basketId is not valid");
            }

            if (item == null)
            {
                return BadRequest("item is not valid");
            }
            if (!item.ItemId.HasValue)
            {
                return BadRequest("Item does not have an Id, please create the item first");
            }

            var currentBasket = repo.UpdateBasket(basketId, item);
            return Ok(currentBasket);
        }

        /// <summary>
        /// Remove an item from a basket
        /// </summary>
        /// <param name="basketId"></param>
        /// <param name="itemId"></param>
        /// <returns></returns>
        [Route("api/v1/{basketId:Guid}/{itemId:Guid}")]
        [HttpDelete]
        public IHttpActionResult RemoveFromBasket(Guid basketId, Guid itemId)
        {
            if (basketId == Guid.Empty)
            {
                return BadRequest("basketId is not valid");
            }

            if (itemId == Guid.Empty)
            {
                return BadRequest("itemId is not valid");
            }

            var currentBasket = repo.RemoveFromBasket(basketId, itemId);
            return Ok(currentBasket);
        }

    }
}