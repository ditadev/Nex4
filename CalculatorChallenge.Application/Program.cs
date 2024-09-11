using CalculatorChallenge.Service;

var calculate = new CalculatorService();
int result = calculate.Add("2,a");
Console.WriteLine(result);