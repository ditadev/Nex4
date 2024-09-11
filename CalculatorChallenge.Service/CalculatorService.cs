namespace CalculatorChallenge.Service;

public class CalculatorService
{
    public (int result, string formula) Add(string input)
    {
        if (string.IsNullOrEmpty(input))
            return (0, "0");

        var delimiters = new List<string> { ",", "\n" };

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
        int sum = 0;
        foreach (var number in numbers)
        {
            if (int.TryParse(number, out int parsedNumber))
            {
                if (parsedNumber <= 1000)
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

        string resultFormula = string.Join("+", formula) + " = " + sum;
        return (sum, resultFormula);
    }
}
