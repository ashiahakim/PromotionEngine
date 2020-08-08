using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromotionEngine.Service
{
    public interface IPromotionService
    {
        int ApplyPromotion(Dictionary<string, int> formRequest);
    }
}
