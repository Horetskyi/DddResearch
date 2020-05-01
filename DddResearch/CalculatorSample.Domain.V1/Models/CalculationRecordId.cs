using System;

namespace CalculatorSample.Domain.V1.Models
{
    public readonly struct CalculationRecordId
    {
        public Guid Guid { get; }

        public CalculationRecordId(Guid guid)
        {
            Guid = guid;
        }

        public static implicit operator Guid(CalculationRecordId id) => id.Guid;
        
        public static CalculationRecordId New()
        {
            return new CalculationRecordId(Guid.NewGuid());
        }
    }
}