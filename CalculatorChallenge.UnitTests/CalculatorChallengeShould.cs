using CalculatorChallenge.Service;
using FluentAssertions;

namespace CalculatorChallenge.UnitTests;

public class CalculatorChallengeShould
{
    private readonly CalculatorService _calculatorService = new();

    [Fact]
    public void Add_CustomDelimiterOfAnyLength_ReturnsSum()
    {
        var result = _calculatorService.Add("//[***]\n11***22***33");
        result.Should().Be(66);
    }
}
