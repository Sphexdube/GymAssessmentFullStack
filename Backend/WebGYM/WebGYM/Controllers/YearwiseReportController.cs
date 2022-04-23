using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebGYM.Interface;
using WebGYM.Models.Model;

namespace WebGYM.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class YearwiseReportController : ControllerBase
    {
        private readonly IReports _reports;
        public YearwiseReportController(IReports reports)
        {
            _reports = reports;
        }

        // POST: api/YearwiseReport
        [HttpPost]
        public List<YearwiseReportModel> Post([FromBody] YearWiseRequestModel value)
        {
            return _reports.Get_YearwisePayment_details(value.YearID);
        }
    }
}
