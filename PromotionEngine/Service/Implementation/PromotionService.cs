using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PromotionEngine.Model;

namespace PromotionEngine.Service.Implementation
{
    public class PromotionService : IPromotionService
    {
        private Dictionary<string, int> _itemUnitPriceLookup;
        private Dictionary<string, CountPriceModel> _promotionOfferLookup;
        public PromotionService()
        {
            CreateItemUnitPriceLookup();
            CreatePromotionLookup();
        }

        private void CreateItemUnitPriceLookup()
        {
            _itemUnitPriceLookup = new Dictionary<string, int>
            {
                { "a", 50 },
                { "b", 30 },
                { "c", 20 },
                { "d", 15 },
                { "e", 10 }
            };
        }

        private void CreatePromotionLookup()
        {
            _promotionOfferLookup = new Dictionary<string, CountPriceModel>
            {
                { "a", new CountPriceModel{ Count = 3, Price = 130 } },
                { "b", new CountPriceModel{ Count = 2, Price = 45 } }
            };
        }
        public int ApplyPromotion(Dictionary<string, int> formRequest)
        {
            throw new NotImplementedException();
        }
    }
}
