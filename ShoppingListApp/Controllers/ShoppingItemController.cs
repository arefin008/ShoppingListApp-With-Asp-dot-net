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
    public class ShoppingItemController : ApiController
    {
        [HttpGet]
        [Route("api/shoppingitems/all")]
        public HttpResponseMessage Get()
        {
            var data = ShoppingItemService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [Route("api/shoppingitems/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var item = ShoppingItemService.Get(id);
            if (item == null)
                return Request.CreateResponse(HttpStatusCode.NotFound, "Shopping item not found.");
            return Request.CreateResponse(HttpStatusCode.OK, item);
        }

        [HttpPost]
        [Route("api/shoppingitems/create")]
        public HttpResponseMessage Create(ShoppingItemDTO itemDto)
        {
            var created = ShoppingItemService.Create(itemDto);
            if (!created)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Failed to create shopping item.");
            return Request.CreateResponse(HttpStatusCode.OK, "Shopping item created successfully.");
        }

        [HttpPut]
        [Route("api/shoppingitems/update")]
        public HttpResponseMessage Update(ShoppingItemDTO itemDto)
        {
            var updated = ShoppingItemService.Update(itemDto);
            if (!updated)
                return Request.CreateResponse(HttpStatusCode.NotFound, "Shopping item not found.");
            return Request.CreateResponse(HttpStatusCode.OK, "Shopping item updated successfully.");
        }

        [HttpDelete]
        [Route("api/shoppingitems/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            var deleted = ShoppingItemService.Delete(id);
            if (!deleted)
                return Request.CreateResponse(HttpStatusCode.NotFound, "Shopping item not found.");
            return Request.CreateResponse(HttpStatusCode.OK, "Shopping item deleted successfully.");
        }

        [HttpPut]
        [Route("api/shoppingitems/markStatus/{id}")]
        public HttpResponseMessage MarkBoughtStatus(int id)
        {
            var toggled = ShoppingItemService.MarkBoughtStatus(id);
            if (!toggled)
                return Request.CreateResponse(HttpStatusCode.NotFound, "Shopping item not found.");
            return Request.CreateResponse(HttpStatusCode.OK, "Item bought status Marked successfully.");
        }

        [HttpGet]
        [Route("api/shoppingitems/category/{category}")]
        public HttpResponseMessage GetByCategory(string category)
        {
            var data = ShoppingItemService.GetByCategory(category);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [Route("api/shoppingitems/sortBy={sortBy}")]
        public HttpResponseMessage GetSortedItems(string sortBy)
        {
            if (string.IsNullOrWhiteSpace(sortBy) || (sortBy != "Type" && sortBy != "Store"))
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid sort parameter. Use 'Type' or 'Store'.");
            }

            var sortedItems = ShoppingItemService.GetSortedItems(sortBy);

            if (sortedItems == null || !sortedItems.Any())
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "No items found for the specified sorting criteria.");
            }

            return Request.CreateResponse(HttpStatusCode.OK, sortedItems);
        }
    }
}
