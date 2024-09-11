namespace CalculatorChallenge.Service;

public interface ICalculatorService
{
    (int result, string formula) Add(string input);
}
