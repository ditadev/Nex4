using CalculatorChallenge.Service;

var calculate = new CalculatorService();
int result = calculate.Add("1\n2,3");
Console.WriteLine(result);