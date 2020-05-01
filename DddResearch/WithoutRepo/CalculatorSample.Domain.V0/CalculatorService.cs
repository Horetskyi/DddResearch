using System;
using CalculatorSample.Domain.V0.Models;

// ReSharper disable ClassNeverInstantiated.Global

namespace CalculatorSample.Domain.V0
{
    public sealed class CalculatorService
    {
        /// <summary>
        /// Pure domain logic
        /// </summary>
        public Changes ExecuteCalculation(CalculatorState state, UserId userId, CalculationExpression expression)
        {
            var user = state.GetUser(userId);
            var calculationResult = expression.Resolve();
            var calculationRecord = new CalculationRecord
            {
                Id = CalculationRecordId.New(),
                UserId = userId,
                Expression = expression,
                Result = calculationResult,
                DateCreated = DateTime.Now,
            };
            user.AddCalculationRecord(calculationRecord);
            return new Changes(user, calculationRecord);
        }
        
        public sealed class Changes
        {
            public User User { get; }
            public CalculationRecord Record { get; }

            public Changes(User user, CalculationRecord record)
            {
                User = user;
                Record = record;
            }
        }
    }
}