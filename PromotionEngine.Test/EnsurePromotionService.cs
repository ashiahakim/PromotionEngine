using System.Collections.Generic;
using AutoFixture;
using AutoFixture.AutoMoq;
using PromotionEngine.Service.Implementation;
using Shouldly;
using Xunit;

namespace PromotionEngine.Test
{
    public class EnsurePromotionService
    {
        private readonly IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());

        private int CallApplyPromotionWithGivenData(Dictionary<string, int> input)
        {
            return _fixture.Create<PromotionService>().ApplyPromotion(input);
        }

        public class CheckCartPriceWithAItems : EnsurePromotionService
        {
            private Dictionary<string, int> CreateInputRequest(int inputA)
            {
                var input = new Dictionary<string, int>
                {
                    { "b", 0 },
                    { "c", 0 },
                    { "d", 0 }
                };
                input.Add("a", inputA);

                return input;
            }

            [Fact]
            public void SingleAItem()
            {
                var input = CreateInputRequest(1);
                var result = CallApplyPromotionWithGivenData(input);
                result.ShouldBe(50);
            }
        }
    }
}
