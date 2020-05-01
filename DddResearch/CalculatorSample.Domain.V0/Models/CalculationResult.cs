using System;
using CalculatorSample.Domain.V0.Exceptions;

namespace CalculatorSample.Domain.V0.Models
{
    public readonly struct CalculationResult
    {
        public CalculationResultType Type { get; }

        private readonly double _resultValue;
        public double ResultValue
        {
            get
            {
                if (Type != CalculationResultType.Value)
                    throw new CalculationResultValueNotExistsException(Type);
                
                return _resultValue;
            }
        }
        
        public TimeSpan ExecutionTime { get; }

        public CalculationResult(double resultValue, TimeSpan executionTime)
        {
            _resultValue = resultValue;
            Type = CalculationResultType.Value;
            ExecutionTime = executionTime;
        }

        public CalculationResult(CalculationResultType type, TimeSpan executionTime)
        {
            if (type == CalculationResultType.Value)
                throw new CalculationResultValueNotSpecifiedException();
            
            Type = type;
            _resultValue = default;
            ExecutionTime = executionTime;
        }
    }
}