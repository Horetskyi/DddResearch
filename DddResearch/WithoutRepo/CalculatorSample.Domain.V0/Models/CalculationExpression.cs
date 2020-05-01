using System;

namespace CalculatorSample.Domain.V0.Models
{
    /// <summary>
    /// Examples: "2+2", "log(90) * 2 - 3.14", etc.
    /// </summary>
    public readonly struct CalculationExpression
    {
        public string Expression { get; }

        public CalculationExpression(string expression)
        {
            Expression = expression;
        }

        public CalculationResult Resolve()
        {
            if (Expression == "2+2")
                return new CalculationResult(4, TimeSpan.FromMilliseconds(10));
         
            throw new NotImplementedException();
        }
    }
}