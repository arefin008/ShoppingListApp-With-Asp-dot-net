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
    public class SharedListController : ApiController
    {
        [HttpGet]
        [Route("api/sharedlists/all")]
        public HttpResponseMessage Get()
        {
            var data = SharedListService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [Route("api/sharedlists/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var sharedList = SharedListService.Get(id);
            if (sharedList == null)
                return Request.CreateResponse(HttpStatusCode.NotFound, "Shared list not found.");
            return Request.CreateResponse(HttpStatusCode.OK, sharedList);
        }

        [HttpPost]
        [Route("api/sharedlists/create")]
        public HttpResponseMessage Create(SharedListDTO sharedListDto)
        {
            var created = SharedListService.Create(sharedListDto);
            if (!created)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Failed to create shared list.");
            return Request.CreateResponse(HttpStatusCode.OK, "Shared list created successfully.");
        }

        [HttpPut]
        [Route("api/sharedlists/update")]
        public HttpResponseMessage Update(SharedListDTO sharedListDto)
        {
            var updated = SharedListService.Update(sharedListDto);
            if (!updated)
                return Request.CreateResponse(HttpStatusCode.NotFound, "Shared list not found.");
            return Request.CreateResponse(HttpStatusCode.OK, "Shared list updated successfully.");
        }

        [HttpDelete]
        [Route("api/sharedlists/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            var deleted = SharedListService.Delete(id);
            if (!deleted)
                return Request.CreateResponse(HttpStatusCode.NotFound, "Shared list not found.");
            return Request.CreateResponse(HttpStatusCode.OK, "Shared list deleted successfully.");
        }
    }
}
