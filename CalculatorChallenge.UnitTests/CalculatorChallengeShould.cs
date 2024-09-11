using CalculatorChallenge.Service;
using FluentAssertions;

namespace CalculatorChallenge.UnitTests;

public class CalculatorChallengeShould
{
    private readonly CalculatorService _calculatorService = new();

    [Fact]
    public void Add_MultipleNumbers_ReturnsSum()
    {
        var exception = Assert.Throws<InvalidOperationException>(() =>  _calculatorService.Add("1,-2,3,-4"));
        Assert.Equal("Negatives not allowed: " + "-2,-4", exception.Message);
    }
}
