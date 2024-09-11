namespace CalculatorChallenge.Service;

public class CalculatorService(string delimiter = ",", bool denyNegatives = true, int upperBound = 1000) : ICalculatorService
{
    public (int result, string formula) Add(string input)
    {
        if (string.IsNullOrEmpty(input))
            return (0, "0");

        var delimiters = new List<string> { delimiter, "\n" };

        if (input.StartsWith("//"))
        {
            var delimiterEndIndex = input.IndexOf('\n');
            var delimiterPart = input.Substring(2, delimiterEndIndex - 2);

            if (delimiterPart.StartsWith("[") && delimiterPart.EndsWith("]"))
            {
                var delimiterTokens = delimiterPart.Split(new[] { "][" }, StringSplitOptions.None);
                foreach (var token in delimiterTokens)
                {
                    delimiters.Add(token.Trim('[', ']'));
                }
            }
            else
            {
                delimiters.Add(delimiterPart);
            }

            input = input.Substring(delimiterEndIndex + 1);
        }

        var numbers = input.Split(delimiters.ToArray(), StringSplitOptions.None);
        var formula = new List<string>();
        var negatives = new List<int>();
        int sum = 0;
        foreach (var number in numbers)
        {
            if (int.TryParse(number, out int parsedNumber))
            {
                if (parsedNumber < 0 && denyNegatives)
                    negatives.Add(parsedNumber);

                if (parsedNumber <= upperBound)
                {
                    sum += parsedNumber;
                    formula.Add(parsedNumber.ToString());
                }
                else
                {
                    formula.Add("0");
                }
            }
            else
            {
                formula.Add("0");
            }
        }

        if (negatives.Any())
            throw new InvalidOperationException("Negatives not allowed: " + string.Join(",", negatives));

        string resultFormula = string.Join("+", formula) + " = " + sum;
        return (sum, resultFormula);
    }
}
