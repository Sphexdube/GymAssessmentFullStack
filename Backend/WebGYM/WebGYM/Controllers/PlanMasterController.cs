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
    public class PlanMasterController : ControllerBase
    {
        private readonly IPlanMaster _planMaster;
        public PlanMasterController(IPlanMaster planMaster)
        {
            _planMaster = planMaster;
        }
        // GET: api/PlanMaster
        [HttpGet]
        public IEnumerable<PlanMasterDisplayViewModel> Get()
        {
            return _planMaster.GetPlanMasterList();
        }

        // GET: api/PlanMaster/5
        [HttpGet("{id}", Name = "GetPlan")]
        public PlanMasterModel Get(int id)
        {
            try
            {
                return _planMaster.GetPlanMasterbyId(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // POST: api/PlanMaster
        [HttpPost]
        public HttpResponseMessage Post([FromBody] PlanMasterModel planMasterViewModel)
        {
            try
            {
                if (_planMaster.CheckPlanExits(planMasterViewModel.PlanName))
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
                    var tempplanMaster = AutoMapper.Mapper.Map<Models.PlanMaster>(planMasterViewModel);
                    tempplanMaster.CreateUserID = Convert.ToInt32(userId);
                    tempplanMaster.RecStatus = true;
                    _planMaster.InsertPlan(tempplanMaster);

                    var response = new HttpResponseMessage()
                    {
                        StatusCode = HttpStatusCode.OK
                    };

                    return response;
                }
            }
            catch (Exception)
            {
                var response = new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.InternalServerError
                };
                return response;
            }
        }

        // PUT: api/PlanMaster/5
        [HttpPut("{id}")]
        public HttpResponseMessage Put(int id, [FromBody] PlanMasterModel planMasterViewModel)
        {
            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.Name);
                var tempplanMaster = AutoMapper.Mapper.Map<Models.PlanMaster>(planMasterViewModel);
                tempplanMaster.CreateUserID = Convert.ToInt32(userId);
                tempplanMaster.RecStatus = true;
                _planMaster.UpdatePlanMaster(tempplanMaster);
                var response = new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK
                };

                return response;
            }
            catch (Exception)
            {
                var response = new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.InternalServerError
                };
                return response;
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
              
                _planMaster.DeletePlan(id);
                var response = new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK
                };

                return response;
            }
            catch (Exception)
            {
                var response = new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.InternalServerError
                };
                return response;
            }
        }
    }
}
