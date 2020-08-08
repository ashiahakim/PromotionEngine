using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PromotionEngine.Service;

namespace PromotionEngine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CostCalculatorController : ControllerBase
    {
        private readonly ICostCalculatorService _costCalculatorService;
        public CostCalculatorController(ICostCalculatorService costCalculatorService)
        {
            _costCalculatorService = costCalculatorService;
        }

        [HttpPost]
        [Route("CalculateCost")]
        public ActionResult<int> CalculateCost(Dictionary<string, int> formRequest)
        {
            var error = formRequest.Values.Where(x => x < 0);
            if (error.Any())
            {
                return BadRequest("Input can't be negative");
            }

            return _costCalculatorService.CalculateCost(formRequest);
        }
    }
}