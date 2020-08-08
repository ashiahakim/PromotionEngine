using System;
using System.Collections.Generic;

namespace PromotionEngine.Service.Implementation
{
    public class CostCalculatorService : ICostCalculatorService
    {
        private readonly IPromotionService _promotionService;
        public CostCalculatorService(IPromotionService promotionService)
        {
            _promotionService = promotionService;
        }

        public int CalculateCost(Dictionary<string, int> formRequest)
        {
            return _promotionService.ApplyPromotion(formRequest);
        }
    }
}
