using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using WebGYM.Interface;
using WebGYM.Models.Model;

namespace WebGYM.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SchemeController : ControllerBase
    {
        private readonly ISchemeMaster _schemeMaster;
        public SchemeController(ISchemeMaster schemeMaster)
        {
            _schemeMaster = schemeMaster;
        }

        // GET: api/Scheme
        [HttpGet]
        public List<Models.SchemeMaster> Get()
        {
            return _schemeMaster.GetSchemeMasterList();
        }

        // GET: api/Scheme/5
        [HttpGet("{id}", Name = "GetScheme")]
        public Models.SchemeMaster Get(int id)
        {
            return _schemeMaster.GetSchemeMasterbyId(id);
        }

        // POST: api/Scheme
        [HttpPost]
        public HttpResponseMessage Post([FromBody] SchemeMasterModel schemeMaster)
        {
            if (ModelState.IsValid)
            {
                if (_schemeMaster.CheckSchemeNameExists(schemeMaster.SchemeName))
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

                    var tempSchemeMaster = AutoMapper.Mapper.Map<Models.SchemeMaster>(schemeMaster);
                    tempSchemeMaster.Createddate = DateTime.Now;
                    tempSchemeMaster.Createdby = Convert.ToInt32(userId);
                    _schemeMaster.AddSchemeMaster(tempSchemeMaster);

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

        // PUT: api/Scheme/5
        [HttpPut("{id}")]
        public HttpResponseMessage Put(int id, [FromBody] SchemeMasterEditViewModel schemeMaster)
        {
            if (string.IsNullOrWhiteSpace(Convert.ToString(id)) || schemeMaster == null)
            {
                var response = new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.BadRequest
                };
                return response;
            }
            else
            {
                var temp = AutoMapper.Mapper.Map<Models.SchemeMaster>(schemeMaster);
                var result = _schemeMaster.UpdateSchemeMaster(temp);

                var response = new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK
                };
                return response;
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public HttpResponseMessage Delete(int id)
        {
            var result = _schemeMaster.DeleteScheme(id);

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
