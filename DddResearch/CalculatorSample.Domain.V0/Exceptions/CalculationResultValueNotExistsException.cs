using CalculatorSample.Domain.V0.Models;

namespace CalculatorSample.Domain.V0.Exceptions
{
    public sealed class CalculationResultValueNotExistsException : CalculatorException
    {
        public CalculationResultValueNotExistsException(CalculationResultType type) 
            : base($"Calculation result is not a value type. Actually it is {type}.")
        {
        }
    }
}