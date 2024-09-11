using CalculatorChallenge.Service;
using FluentAssertions;

namespace CalculatorChallenge.UnitTests;

public class CalculatorChallengeShould
{
    private readonly CalculatorService _calculatorService = new();

    [Fact]
    public void Add_MultipleNumbers_ReturnsSum()
    {
        var result = _calculatorService.Add("1\n2,3");
        result.Should().Be(6);
    }
}
