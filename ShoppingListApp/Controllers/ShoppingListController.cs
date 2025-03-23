using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShoppingListApp.Controllers
{
    public class ShoppingListController : ApiController
    {
        [HttpGet]
        [Route("api/shoppinglists/all")]
        public HttpResponseMessage Get()
        {
            var data = ShoppingListService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [Route("api/shoppinglists/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var list = ShoppingListService.Get(id);
            if (list == null)
                return Request.CreateResponse(HttpStatusCode.NotFound, "Shopping list not found.");
            return Request.CreateResponse(HttpStatusCode.OK, list);
        }

        [HttpPost]
        [Route("api/shoppinglists/create")]
        public HttpResponseMessage Create(ShoppingListDTO shoppingListDto)
        {
            var created = ShoppingListService.Create(shoppingListDto);
            if (!created)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Failed to create shopping list.");
            return Request.CreateResponse(HttpStatusCode.OK, "Shopping list created successfully.");
        }

        [HttpPut]
        [Route("api/shoppinglists/update")]
        public HttpResponseMessage Update(ShoppingListDTO shoppingListDto)
        {
            var updated = ShoppingListService.Update(shoppingListDto);
            if (!updated)
                return Request.CreateResponse(HttpStatusCode.NotFound, "Shopping list not found.");
            return Request.CreateResponse(HttpStatusCode.OK, "Shopping list updated successfully.");
        }

        [HttpDelete]
        [Route("api/shoppinglists/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            var deleted = ShoppingListService.Delete(id);
            if (!deleted)
                return Request.CreateResponse(HttpStatusCode.NotFound, "Shopping list not found.");
            return Request.CreateResponse(HttpStatusCode.OK, "Shopping list deleted successfully.");
        }

        [HttpGet]
        [Route("api/shoppinglists/items/{id}")]
        public HttpResponseMessage GetWithItems(int id)
        {
            var list = ShoppingListService.GetwithItems(id);
            if (list == null)
                return Request.CreateResponse(HttpStatusCode.NotFound, "Shopping list not found.");
            return Request.CreateResponse(HttpStatusCode.OK, list);
        }

        [HttpGet]
        [Route("api/shoppinglists/totalEstimateByList/{id}")]
        public HttpResponseMessage GetTotalPriceEstimate(int id)
        {
            var shoppingListWithTotal = ShoppingListService.TotalPriceEstimation(id);

            if (shoppingListWithTotal == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Shopping list not found.");
            }

            return Request.CreateResponse(HttpStatusCode.OK, shoppingListWithTotal);
        }
    }
}
