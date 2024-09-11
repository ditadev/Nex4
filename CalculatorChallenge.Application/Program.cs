using CalculatorChallenge.Service;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = new ServiceCollection()
    .AddSingleton<ICalculatorService, CalculatorService>(provider => new CalculatorService(
        delimiter: args.Length >= 1 ? args[0] : ",",
        denyNegatives: args.Length < 2 || !bool.TryParse(args[1], out bool toggleNegatives) || toggleNegatives,
        upperBound: args.Length >= 3 && int.TryParse(args[2], out int bound) ? bound : 1000
    ))
    .BuildServiceProvider();

var calculator = serviceProvider.GetService<ICalculatorService>();

Console.WriteLine("Enter numbers to add, or press Ctrl+C to exit:");

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