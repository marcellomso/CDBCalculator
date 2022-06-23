using CDBCalc.Application;
using CDBCalc.Domain;
using Microsoft.AspNetCore.Mvc;

namespace CDBCalc.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculateInvestmentController : ControllerBase
    {
        private readonly ICalcService service;

        public CalculateInvestmentController(ICalcService service)
        {
            this.service = service;
        }

        [HttpPost]
        public ActionResult<InvestmentResult> Post(Cdb data)
        {
            return Ok(service.Calculate(data));
        }
    }
}