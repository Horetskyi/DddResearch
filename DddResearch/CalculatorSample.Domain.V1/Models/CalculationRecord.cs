using System;

namespace CalculatorSample.Domain.V1.Models
{
    public sealed class CalculationRecord
    {
        public CalculationRecordId Id { get; set; }
        public UserId UserId { get; set; }
        public CalculationExpression Expression { get; set; }
        public CalculationResult Result { get; set; }
        public DateTime DateCreated { get; set; }
    }
}