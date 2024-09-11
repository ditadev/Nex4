using CalculatorChallenge.Service;
using FluentAssertions;

namespace CalculatorChallenge.UnitTests;

public class CalculatorChallengeShould
{
    private readonly CalculatorService _calculatorService = new();

    [Fact]
    public void Add_DisplayFormula_ReturnsCorrectFormula()
    {
        var (result, formula) = _calculatorService.Add("2,,4,rrrr,1001,6");
        result.Should().Be(12);
        formula.Should().Be("2+0+4+0+0+6 = 12");
    }
}
