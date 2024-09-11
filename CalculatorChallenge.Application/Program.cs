using CalculatorChallenge.Service;

var calculate = new CalculatorService();
int result = calculate.Add("1,-2,3,-4");
Console.WriteLine(result);