using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using Moq;
using PromotionEngine.Service;
using PromotionEngine.Service.Implementation;
using Shouldly;
using Xunit;

namespace PromotionEngine.Test
{
    public class EnsureCostCalculatorService
    {
        private readonly IFixture _fixture = new Fixture().Customize(new AutoMoqCustomization());
        private readonly Mock<IPromotionService> _mockPromotionService;

        public EnsureCostCalculatorService()
        {
            _mockPromotionService = _fixture.Freeze<Mock<IPromotionService>>();
            _mockPromotionService
                .Setup(x => x.ApplyPromotion(It.IsAny<Dictionary<string, int>>()))
                .Returns(280);
            _fixture.Register(() => _mockPromotionService.Object);
        }

        private int CallCalculateCostWithGivenData()
        {
            var input = new Dictionary<string, int>
                {
                    { "a", 3 },
                    { "b", 5 },
                    { "c", 1 },
                    { "d", 1 }
                };
            return _fixture.Create<CostCalculatorService>().CalculateCost(input);
        }

        [Fact]
        public void ReturnsCorrectResponse()
        {
            var result = CallCalculateCostWithGivenData();
            result.ShouldBe(280);
        }
    }
}
