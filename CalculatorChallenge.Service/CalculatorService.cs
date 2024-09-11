namespace CalculatorChallenge.Service;

public class CalculatorService
{
    public int Add(string input)
    {
        if (string.IsNullOrEmpty(input))
            return 0;

        var numbers = input.Split(',');

        if (numbers.Length > 2)
            throw new InvalidOperationException("More than two numbers are not allowed.");

        int sum = 0;
        foreach (var number in numbers)
        {
            if (int.TryParse(number, out int parsedNumber))
            {
                sum += parsedNumber;
            }
            else
            {
                sum += 0; // Treat invalid number as 0
            }
        }

        return sum;
    }
}
