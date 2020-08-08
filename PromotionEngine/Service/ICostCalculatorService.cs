using System.Collections.Generic;

namespace PromotionEngine.Service
{
    public interface ICostCalculatorService
    {
        int CalculateCost(Dictionary<string, int> formRequest);
    }
}
