using System;
using System.Runtime.Serialization;

namespace CalculatorSample.Domain.V0.Exceptions
{
    public class CalculatorException : Exception
    {
        protected CalculatorException()
        {
        }

        protected CalculatorException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        protected CalculatorException(string message) : base(message)
        {
        }

        protected CalculatorException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}