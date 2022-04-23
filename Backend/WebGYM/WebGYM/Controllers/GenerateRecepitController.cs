using Microsoft.AspNetCore.Mvc;
using System;
using WebGYM.Interface;
using WebGYM.Models.Model;

namespace WebGYM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenerateRecepitController : ControllerBase
    {
        private readonly IGenerateRecepit _generateRecepit;
        public GenerateRecepitController(IGenerateRecepit generateRecepit)
        {
            _generateRecepit = generateRecepit;
        }

        // POST: api/GenerateRecepit
        [HttpPost]
        public GenerateRecepitModel Post([FromBody] GenerateRecepitRequestModel generateRecepitRequestModel)
        {
            try
            {
                return _generateRecepit.Generate(generateRecepitRequestModel.PaymentId);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
