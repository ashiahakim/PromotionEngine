using System.Collections.Generic;
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
            var sum = 0;
            foreach (var promotionKey in _promotionOfferLookup.Keys)
            {
                if (formRequest.ContainsKey(promotionKey))
                {
                    sum = GetSumAfterPromotionType1(promotionKey, formRequest[promotionKey], sum);
                    RemoveKeyFromRequest(formRequest, promotionKey);
                }
            }

            sum = GetSumAfterPromotionType2(formRequest, sum);
            RemoveKeyFromRequest(formRequest, "c");
            RemoveKeyFromRequest(formRequest, "d");

            sum = GetSumForNonPromotionItem(formRequest, sum);

            return sum;
        }

        private static void RemoveKeyFromRequest(Dictionary<string, int> formRequest, string key)
        {
            if (formRequest.ContainsKey(key))
            {
                formRequest.Remove(key);
            }
        }

        private int GetSumAfterPromotionType1(string key, int inputValue, int sum)
        {
            var input = inputValue;
            var discountCount = _promotionOfferLookup[key].Count;
            var discountPrice = _promotionOfferLookup[key].Price;
            sum = sum + (input / discountCount) * discountPrice + (input % discountCount) * GetValuefromLookup(_itemUnitPriceLookup, key);

            return sum;
        }

        private int GetValuefromLookup(Dictionary<string, int> lookup, string key)
        {
            if (lookup.ContainsKey(key))
            {
                return lookup[key];
            }
            return 0;
        }

        private int GetSumAfterPromotionType2(Dictionary<string, int> inputValue, int sum)
        {

            var inputC = GetValuefromLookup(inputValue, "c");
            var inputD = GetValuefromLookup(inputValue, "d");
            var diff = 0;
            if (inputC >= inputD)
            {
                diff = inputC - inputD;
                sum = sum + inputD * 30;
                return sum + (diff * GetValuefromLookup(_itemUnitPriceLookup, "c"));
            }
            diff = inputD - inputC;
            sum = sum + inputC * 30;
            sum = sum + (diff * GetValuefromLookup(_itemUnitPriceLookup, "d"));

            return sum;
        }
        private int GetSumForNonPromotionItem(Dictionary<string, int> inputValue, int sum)
        {
            foreach (var key in inputValue.Keys)
            {
                if (_itemUnitPriceLookup.ContainsKey(key))
                {
                    sum = sum + (inputValue[key] * _itemUnitPriceLookup[key]);
                }
            }

            return sum;
        }


    }
}
