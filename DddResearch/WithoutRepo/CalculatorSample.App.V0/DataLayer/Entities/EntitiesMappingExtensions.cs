using CalculatorSample.Domain.V0.Models;

namespace CalculatorSample.App.V0.DataLayer.Entities
{
    public static class EntitiesMappingExtensions
    {
        public static UserEntity MapToEntity(this User user)
        {
            return new UserEntity
            {
                Id = user.Id,
                LastCalculatedRecordId = user.LastCalculationRecordId,
            };
        }
        
        public static CalculationRecordEntity MapToEntity(this CalculationRecord record)
        {
            return new CalculationRecordEntity
            {
                Id = record.Id,
                UserId = record.UserId,
                Expression = record.Expression.Expression,
                DateCreated = record.DateCreated,
                ExecutionTime = record.Result.ExecutionTime,
                ResultType = record.Result.Type,
                ResultValue = record.Result.Type == CalculationResultType.Value ? record.Result.ResultValue : default,
            };
        }

        public static CalculationRecord MapToDomain(this CalculationRecordEntity record)
        {
            return new CalculationRecord
            {
                Id = new CalculationRecordId(record.Id),
                UserId = new UserId(record.UserId),
                Expression = new CalculationExpression(record.Expression),
                Result = record.ResultType == CalculationResultType.Value
                    ? new CalculationResult(record.ResultValue, record.ExecutionTime)
                    : new CalculationResult(record.ResultType, record.ExecutionTime),
                DateCreated = record.DateCreated,
            };
        }
    }
}