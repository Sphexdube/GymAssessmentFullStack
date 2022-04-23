using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using WebGYM.Interface;
using WebGYM.Models.Model;

namespace WebGYM.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RenewalDetailsController : ControllerBase
    {
        private readonly IRenewal _renewal;
        public RenewalDetailsController(IRenewal renewal)
        {
            _renewal = renewal;
        }
          
        // POST: api/RenewalDetails
        [HttpPost]
        public RenewalModel Post([FromBody] MemberNoRequest memberNoRequest)
        {
            var userId = Convert.ToInt32(this.User.FindFirstValue(ClaimTypes.Name));
            return _renewal.GetMemberNo(memberNoRequest.MemberNo, userId);
        }
    }
}
