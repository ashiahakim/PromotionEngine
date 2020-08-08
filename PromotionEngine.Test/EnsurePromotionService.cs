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

            [Fact]
            public void ThreeAItem()
            {
                var input = CreateInputRequest(3);
                var result = CallApplyPromotionWithGivenData(input);
                result.ShouldBe(130);
            }

            [Fact]
            public void SevenAItem()
            {
                var input = CreateInputRequest(7);
                var result = CallApplyPromotionWithGivenData(input);
                result.ShouldBe(310);
            }
        }

        public class CheckCartPriceWithBItems : EnsurePromotionService
        {
            private Dictionary<string, int> CreateInputRequest(int inputB)
            {
                var input = new Dictionary<string, int>
                {
                    { "a", 0 },
                    { "c", 0 },
                    { "d", 0 }
                };
                input.Add("b", inputB);

                return input;
            }

            [Fact]
            public void SingleBItem()
            {
                var input = CreateInputRequest(1);
                var result = CallApplyPromotionWithGivenData(input);
                result.ShouldBe(30);
            }

            [Fact]
            public void ThreeBItem()
            {
                var input = CreateInputRequest(3);
                var result = CallApplyPromotionWithGivenData(input);
                result.ShouldBe(75);
            }

            [Fact]
            public void SevenBItem()
            {
                var input = CreateInputRequest(7);
                var result = CallApplyPromotionWithGivenData(input);
                result.ShouldBe(165);
            }
        }

        public class CheckCartPriceWithCAndDItems : EnsurePromotionService
        {
            private Dictionary<string, int> CreateInputRequest(int inputC, int inputD)
            {
                var input = new Dictionary<string, int>
                {
                    { "a", 0 },
                    { "b", 0 }
                };
                input.Add("c", inputC);
                input.Add("d", inputD);

                return input;
            }

            [Fact]
            public void SingleCItem()
            {
                var input = CreateInputRequest(1, 0);
                var result = CallApplyPromotionWithGivenData(input);
                result.ShouldBe(20);
            }

            [Fact]
            public void SingleDItem()
            {
                var input = CreateInputRequest(0, 1);
                var result = CallApplyPromotionWithGivenData(input);
                result.ShouldBe(15);
            }

            [Fact]
            public void SingleCSingleDItem()
            {
                var input = CreateInputRequest(1, 1);
                var result = CallApplyPromotionWithGivenData(input);
                result.ShouldBe(30);
            }

            [Fact]
            public void MoreCLessD()
            {
                var input = CreateInputRequest(3, 2);
                var result = CallApplyPromotionWithGivenData(input);
                result.ShouldBe(80);
            }

            [Fact]
            public void LessCMoreD()
            {
                var input = CreateInputRequest(2, 3);
                var result = CallApplyPromotionWithGivenData(input);
                result.ShouldBe(75);
            }
        }
    }
}
