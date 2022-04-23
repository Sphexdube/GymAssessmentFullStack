using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WebGYM.Interface;
using WebGYM.Models.Model;

namespace WebGYM.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MonthwiseReportController : ControllerBase
    {

        private readonly IReports _reports;
        public MonthwiseReportController(IReports reports)
        {
            _reports = reports;
        }

        // POST: api/MonthwiseReport
        [HttpPost]
        public List<MonthWiseReportModel> Post([FromBody] MonthwiseRequestModel value)
        {
            try
            {
                return _reports.Get_MonthwisePayment_details(value.MonthId);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
