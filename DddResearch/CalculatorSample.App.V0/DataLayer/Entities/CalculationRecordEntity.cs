using System;
using CalculatorSample.Domain.V0.Models;

namespace CalculatorSample.App.V0.DataLayer.Entities
{
    public sealed class CalculationRecordEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Expression { get; set; }
        public CalculationResultType ResultType { get; set; }
        public double ResultValue { get; set; }
        public TimeSpan ExecutionTime { get; set; }
        public DateTime DateCreated { get; set; }
    }
}