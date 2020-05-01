namespace CalculatorSample.Domain.V0.Exceptions
{
    public sealed class CalculationResultValueNotSpecifiedException : CalculatorException
    {
        public CalculationResultValueNotSpecifiedException() 
            : base($"Cannot create CalculationResult with type Value but without an actually Value")
        {
        }
    }
}