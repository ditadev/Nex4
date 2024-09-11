using CalculatorChallenge.Service;

var calculate = new CalculatorService();
Console.WriteLine("Enter , separated numbers to add, or press Ctrl+C to exit:");

while (true)
{
    try
    {
        string input = Console.ReadLine();
        var (result, formula) = calculate.Add(input);
        Console.WriteLine($"Result: {result} | Formula: {formula}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}