using CalculatorChallenge.Service;
using FluentAssertions;

namespace CalculatorChallenge.UnitTests;

public class CalculatorChallengeShould
{
    private readonly CalculatorService _calculatorService = new();

    [Fact]
    public void Add_CustomDelimiter_ReturnsSum()
    {
        var result = _calculatorService.Add("//#\n2#5");
        result.Should().Be(7);
    }
}
