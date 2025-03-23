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
    public class UserController : ApiController
    {
        [HttpGet]
        [Route("api/users/all")]
        public HttpResponseMessage Get()
        {
            var users = UserService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, users);
        }

        [HttpGet]
        [Route("api/users/{id}")]
        public HttpResponseMessage Get(string id)
        {
            var user = UserService.Get(id);
            if (user == null)
                return Request.CreateResponse(HttpStatusCode.NotFound, "User not found.");
            return Request.CreateResponse(HttpStatusCode.OK, user);
        }

        [HttpPost]
        [Route("api/users/create")]
        public HttpResponseMessage Create(UserDTO userDto)
        {
            var createdUser = UserService.Create(userDto);
            if (createdUser == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Failed to create user.");
            return Request.CreateResponse(HttpStatusCode.OK, createdUser);
        }

        [HttpDelete]
        [Route("api/users/{id}")]
        public HttpResponseMessage Delete(string id)
        {
            var deleted = UserService.Delete(id);
            if (!deleted)
                return Request.CreateResponse(HttpStatusCode.NotFound, "User not found.");
            return Request.CreateResponse(HttpStatusCode.OK, "User deleted successfully.");
        }

        [HttpPost]
        [Route("api/users/authenticate")]
        public HttpResponseMessage Authenticate(string username, string password)
        {
            var authenticated = UserService.Authenticate(username, password);
            if (!authenticated)
                return Request.CreateResponse(HttpStatusCode.Unauthorized, "Invalid credentials.");
            return Request.CreateResponse(HttpStatusCode.OK, "Authentication successful.");
        }

        [HttpGet]
        [Route("api/users/{id}/withLists")]
        public HttpResponseMessage GetWithLists(string id)
        {
            var userWithLists = UserService.GetWithLists(id);
            if (userWithLists == null)
                return Request.CreateResponse(HttpStatusCode.NotFound, "User not found.");
            return Request.CreateResponse(HttpStatusCode.OK, userWithLists);
        }
    }
}
