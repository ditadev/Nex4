using CalculatorChallenge.Service;
using FluentAssertions;

namespace CalculatorChallenge.UnitTests;

public class CalculatorChallengeShould
{
    private readonly CalculatorService _calculatorService = new();

    [Fact]
    public void Add_NumbersGreaterThan1000_IgnoredInSum()
    {
        var result = _calculatorService.Add("2,1001,6");
        result.Should().Be(8);
    }
}
