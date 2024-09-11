namespace CalculatorChallenge.Service;

public class CalculatorService
{
    public int Add(string input)
    {
        if (string.IsNullOrEmpty(input))
            return 0;

        var delimiters = new[] { ",", "\n" };
        var numbers = input.Split(delimiters, StringSplitOptions.None);

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
