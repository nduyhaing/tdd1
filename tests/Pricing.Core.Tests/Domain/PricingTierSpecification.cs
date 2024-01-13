using FluentAssertions;
using Pricing.Core.Domain;
using Pricing.Core.Domain.Exceptions;

namespace Pricing.Core.Tests.Domain;

public class PricingTierSpecification
{
    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(25)]
    public void Should_throw_invalid_pricing_tier_when_hour_limit_is_invalid(int hour)
    {
        var create = () => new PriceTier(hour, 1);

        create.Should().ThrowExactly<InvalidPricingTierException>();
    }

    [Fact]
    public void Should_throw_invalid_pricing_tier_exception_when_price_is_negative()
    {
        var create = () => new PriceTier(1, -1);

        create.Should().Throw<InvalidPricingTierException>();
    }

    [Fact]
    public void Should_calculate_the_full_price_for_tier()
    {
        // arrange
        var tier = new PriceTier(5, 2);
        // act
        var fullPrice = tier.CalculateFullPrice();
        // assert
        fullPrice.Should().Be(10);
    }
}