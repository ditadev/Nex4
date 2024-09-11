using CalculatorChallenge.Service;

var calculate = new CalculatorService();
var (result, formula) = calculate.Add("2,,4,rrrr,1001,6");
Console.WriteLine(result);
Console.WriteLine(formula);