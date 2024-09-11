using CalculatorChallenge.Service;

var calculate = new CalculatorService();
int result = calculate.Add("2,1001,6");
Console.WriteLine(result);