namespace CalculatorChallenge.Service;

public class CalculatorService
{
    public int Add(string input)
    {
        if (string.IsNullOrEmpty(input))
            return 0;

        string delimiter = ",";
        if (input.StartsWith("//"))
        {
            var delimiterEndIndex = input.IndexOf('\n');
            var delimiterPart = input.Substring(2, delimiterEndIndex - 2);

            if (delimiterPart.StartsWith("[") && delimiterPart.EndsWith("]"))
            {
                delimiter = delimiterPart.Substring(1, delimiterPart.Length - 2);
            }
            else
            {
                delimiter = delimiterPart;
            }

            input = input.Substring(delimiterEndIndex + 1);
        }

        var delimiters = new[] { delimiter, "\n" };
        var numbers = input.Split(delimiters, StringSplitOptions.None);

        var negatives = new List<int>();
        int sum = 0;
        foreach (var number in numbers)
        {
            if (int.TryParse(number, out int parsedNumber))
            {
                if (parsedNumber < 0)
                    negatives.Add(parsedNumber);

                if (parsedNumber <= 1000)
                    sum += parsedNumber > 0 ? parsedNumber : 0;
            }
        }

        if (negatives.Any())
            throw new InvalidOperationException("Negatives not allowed: " + string.Join(",", negatives));

        return sum;
    }
}
