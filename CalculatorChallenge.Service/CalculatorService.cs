namespace CalculatorChallenge.Service;

public class CalculatorService
{
    public int Add(string input)
    {
        if (string.IsNullOrEmpty(input))
            return 0;

        var delimiters = new[] { ",", "\n" };
        var numbers = input.Split(delimiters, StringSplitOptions.None);

        var negatives = new List<int>();
        int sum = 0;
        foreach (var number in numbers)
        {
            if (int.TryParse(number, out int parsedNumber))
            {
                if (parsedNumber < 0)
                    negatives.Add(parsedNumber);

                sum += parsedNumber > 0 ? parsedNumber : 0;
            }
        }

        if (negatives.Any())
            throw new InvalidOperationException("Negatives not allowed: " + string.Join(",", negatives));

        return sum;
    }
}
