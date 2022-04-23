﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WebGYM.Interface;
using WebGYM.Models.Model;

namespace WebGYM.Controllers
{
    /// <summary>
    /// View All Active Plan Master Related API EndPoints
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AllActivePlanMasterController : ControllerBase
    {

        private readonly IPlanMaster _planMaster;
        public AllActivePlanMasterController(IPlanMaster planMaster)
        {
            _planMaster = planMaster;
        }

        //
        /// <summary>
        /// Get All Active Plan or  Get Specific Active Plan by ID
        /// </summary>
        /// <param name="id"></param>
        /// <remarks>
        ///  GET: api/AllActivePlanMaster/5
        /// </remarks>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetAllActivePlan")]
        public List<ActivePlanModel> Get(int? id)
        {
            try
            {
                if (id != null)
                {
                    return _planMaster.GetActivePlanMasterList(id);
                }
                else
                {
                    return new List<ActivePlanModel>()
                {
                    new ActivePlanModel()
                    {
                        PlanID = string.Empty,
                        PlanName = ""
                    }
                };
                }
            }
            catch (Exception)
            {

                throw;
            }

        }


    }
}
