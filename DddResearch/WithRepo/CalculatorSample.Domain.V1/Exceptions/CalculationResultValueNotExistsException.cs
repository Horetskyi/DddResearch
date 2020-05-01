using CalculatorSample.Domain.V1.Models;

namespace CalculatorSample.Domain.V1.Exceptions
{
    public sealed class CalculationResultValueNotExistsException : CalculatorException
    {
        public CalculationResultValueNotExistsException(CalculationResultType type) 
            : base($"Calculation result is not a value type. Actually it is {type}.")
        {
        }
    }
}