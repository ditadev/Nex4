using CalculatorChallenge.Domain;

namespace CalculatorChallenge.Service;

public class CalculatorService(string delimiter = ",", bool denyNegatives = true, int upperBound = 1000) : ICalculatorService
{
    public (int result, string formula) Add(string input, OperationType operation)
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
        int result = operation == OperationType.Multiply ? 1 : 0;
        foreach (var number in numbers)
        {
            if (int.TryParse(number, out int parsedNumber))
            {
                if (parsedNumber < 0 && denyNegatives)
                    negatives.Add(parsedNumber);

                if (parsedNumber <= upperBound)
                {
                    if (operation == OperationType.Add)
                        result += parsedNumber;
                    else if (operation == OperationType.Subtract)
                        result -= parsedNumber;
                    else if (operation == OperationType.Multiply)
                        result *= parsedNumber;
                    else if (operation == OperationType.Divide && parsedNumber != 0)
                        result /= parsedNumber;

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

        string resultFormula = string.Join(operation == OperationType.Add ? "+" : operation == OperationType.Subtract ? "-" : operation == OperationType.Multiply ? "*" : "/", formula) + " = " + result;
        return (result, resultFormula);
    }
}
