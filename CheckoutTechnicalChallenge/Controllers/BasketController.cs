﻿using CheckoutTechnicalChallenge.Interfaces;
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
    public class BasketController : ApiController
    {
        IDataAccessRepo repo;

        public BasketController()
        {
            repo = new FileDataAccessRepo();
        }

        [Route("api/v1")]
        [HttpPost]
        public IHttpActionResult CreateBasket()
        {
            var result = repo.CreateBasket();
            return Ok(result);
        }

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

        [Route("api/v1/{basketId:Guid}")]
        [HttpPut]
        public IHttpActionResult AddOrUpdateBasket(Guid basketId, [FromBody]Item item)
        {
            if (basketId == Guid.Empty)
            {
                return BadRequest("basketId is not valid");
            }

            if (item == null)
            {
                return BadRequest("item is not valid");
            }

            var currentBasket = repo.AddOrUpdateBasket(basketId, item);
            return Ok(currentBasket);
        }

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