using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PromotionEngine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CostCalculatorController : ControllerBase
    {
        [HttpPost]
        [Route("CalculateCost")]
        public ActionResult<int> CalculateCost(Dictionary<string, int> formRequest)
        {
            throw new NotImplementedException();
        }
    }
}