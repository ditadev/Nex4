using CalculatorChallenge.Service;

var calculate = new CalculatorService();
int result = calculate.Add("//#\n2#5");
Console.WriteLine(result);