using CalculatorChallenge.Service;

var delimiter = ",";
var denyNegatives = false;
var upperBound = 1000;

if (args.Length >= 1)
    delimiter = args[0];

if (args.Length >= 2 && bool.TryParse(args[1], out bool toggleNegatives))
    denyNegatives = toggleNegatives;

if (args.Length >= 3 && int.TryParse(args[2], out int bound))
    upperBound = bound;

var calculator = new CalculatorService(delimiter, denyNegatives, upperBound);
Console.WriteLine($"Enter {delimiter} separated numbers to add, or press Ctrl+C to exit:");

while (true)
{
    try
    {
        string input = Console.ReadLine();
        var (result, formula) = calculator.Add(input);
        Console.WriteLine($"Result: {result} | Formula: {formula}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}