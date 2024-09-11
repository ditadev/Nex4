using CalculatorChallenge.Service;
using FluentAssertions;

namespace CalculatorChallenge.UnitTests;

public class CalculatorChallengeShould
{
    private readonly CalculatorService _calculatorService;
    
    public CalculatorChallengeShould()
    {
        _calculatorService = new CalculatorService();
    }
    [Fact]
    public void Add_EmptyString_ReturnsZero()
    {
        var result = _calculatorService.Add("");
        result.Should().Be(0);
    }

    [Fact]
    public void Add_SingleNumber_ReturnsSameNumber()
    {
        var result = _calculatorService.Add("20");
        result.Should().Be(20);
    }

    [Fact]
    public void Add_TwoValidNumbers_ReturnsSum()
    {
        var result = _calculatorService.Add("1,5000");
        result.Should().Be(5001);
    }

    [Fact]
    public void Add_InvalidNumber_ReturnsSumIgnoringInvalidNumber()
    {
        var result = _calculatorService.Add("5,tytyt");
        result.Should().Be(5);
    }

    [Fact]
    public void Add_MoreThanTwoNumbers_ThrowsException()
    {
        var exception = Assert.Throws<InvalidOperationException>(() => _calculatorService.Add("1,2,3"));
        Assert.Equal("More than two numbers are not allowed.", exception.Message);
    }
}
