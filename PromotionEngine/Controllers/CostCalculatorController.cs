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
            return _costCalculatorService.CalculateCost(formRequest);
        }
    }
}