using CalculatorChallenge.Service;
using FluentAssertions;

namespace CalculatorChallenge.UnitTests;

public class CalculatorChallengeShould
{
    private readonly CalculatorService _calculatorService = new();

    [Fact]
    public void Add_MultipleDelimitersOfAnyLength_ReturnsSum()
    {
        var result = _calculatorService.Add("//[*][!!][r9r]\n11r9r22*33!!44");
        result.Should().Be(110);
    }
}
