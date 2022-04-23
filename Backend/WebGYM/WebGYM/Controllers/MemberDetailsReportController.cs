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
    public class MemberDetailsReportController : ControllerBase
    {
        private readonly IReports _reports;
        public MemberDetailsReportController(IReports reports)
        {
            _reports = reports;
        }

        // GET: api/MemberDetailsReport
        [HttpGet]
        public List<MemberDetailsReportModel> Get()
        {
            try
            {
                return _reports.Generate_AllMemberDetailsReport();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
