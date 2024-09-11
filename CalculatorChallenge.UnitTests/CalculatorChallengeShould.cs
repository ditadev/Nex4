using CalculatorChallenge.Domain;
using CalculatorChallenge.Service;
using FluentAssertions;

namespace CalculatorChallenge.UnitTests;

public class CalculatorChallengeShould
{
    private readonly ICalculatorService _calculatorService = new CalculatorService();

    [Fact]
    public void Add_DisplayFormula_ReturnsCorrectFormula()
    {
        var (result, formula) = _calculatorService.Add("2,,4,rrrr,1001,6", OperationType.Add);
        result.Should().Be(12);
        formula.Should().Be("2+0+4+0+0+6 = 12");
    }
    
    [Theory]
    [InlineData(",", false, 1000, "2,1,5000,3", -6, "2-1-0-3 = -6", OperationType.Subtract)] // No negative numbers, upper bound is 1000
    [InlineData("/", false, 1000, "2/1/5000/-3", 0, "2+1+0+-3 = 0", OperationType.Add)] // Custom delimiter "/"
    public void Add_DisplayFormula_ReturnsCorrectFormula_With_CustomizableArgument_With_CustomOperationType(
        string delimiter,
        bool denyNegatives,
        int upperBound,
        string input,
        int expectedResult,
        string expectedFormula,
        OperationType operationType)
    {
        var calculator = new CalculatorService(delimiter, denyNegatives, upperBound);
        var (result, formula) = calculator.Add(input, operationType);
        result.Should().Be(expectedResult);
        formula.Should().Be(expectedFormula);
    }
}
