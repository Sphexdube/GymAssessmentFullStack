using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using WebGYM.Interface;
using WebGYM.Models.Model;

namespace WebGYM.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GetTotalAmountController : ControllerBase
    {
        private readonly IPlanMaster _planMaster;
        public GetTotalAmountController(IPlanMaster planMaster)
        {
            _planMaster = planMaster;
        }
       

        // POST: api/GetTotalAmount
        [HttpPost]
        public string Post([FromBody] AmountRequestModel amountRequest)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return _planMaster.GetAmount(amountRequest.PlanId, amountRequest.SchemeId);
                }
                else
                {
                    return string.Empty;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
