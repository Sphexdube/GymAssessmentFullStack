using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using WebGYM.Common;
using WebGYM.Interface;
using WebGYM.Models.Model;

namespace WebGYM.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUsers _users;
        public UserController(IUsers users)
        {
            _users = users;
        }
        // GET: api/User
        [HttpGet]
        public IEnumerable<Models.Users> Get()
        {
            return _users.GetAllUsers();
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "GetUsers")]
        public Models.Users Get(int id)
        {
            return _users.GetUsersbyId(id);
        }

        // POST: api/User
        [HttpPost]
        public HttpResponseMessage Post([FromBody] UsersViewModel users)
        {
            if (ModelState.IsValid)
            {
                if (_users.CheckUsersExits(users.UserName))
                {
                    var response = new HttpResponseMessage()
                    {
                        StatusCode = HttpStatusCode.Conflict
                    };

                    return response;
                }
                else
                {
                    var userId = this.User.FindFirstValue(ClaimTypes.Name);
                    var tempUsers = AutoMapper.Mapper.Map<Models.Users>(users);
                    tempUsers.CreatedDate = DateTime.Now;
                    tempUsers.Createdby = Convert.ToInt32(userId);
                    tempUsers.Password = EncryptionLibrary.EncryptText(users.Password);
                    _users.InsertUsers(tempUsers);

                    var response = new HttpResponseMessage()
                    {
                        StatusCode = HttpStatusCode.OK
                    };

                    return response;
                }
            }
            else
            {
                var response = new HttpResponseMessage()
                {

                    StatusCode = HttpStatusCode.BadRequest
                };

                return response;
            }

        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public HttpResponseMessage Put(int id, [FromBody] UsersViewModel users)
        {
            if (ModelState.IsValid)
            {

                var tempUsers = AutoMapper.Mapper.Map<Models.Users>(users);
                tempUsers.CreatedDate = DateTime.Now;
                _users.UpdateUsers(tempUsers);

                var response = new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK
                };

                return response;

            }
            else
            {
                var response = new HttpResponseMessage()
                {

                    StatusCode = HttpStatusCode.BadRequest
                };

                return response;
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public HttpResponseMessage Delete(int id)
        {
            var result = _users.DeleteUsers(id);

            if (result)
            {
                var response = new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK
                };
                return response;
            }
            else
            {
                var response = new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.BadRequest
                };
                return response;
            }
        }
    }
}
