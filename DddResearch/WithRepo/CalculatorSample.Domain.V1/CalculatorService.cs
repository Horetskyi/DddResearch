using System;
using System.Threading.Tasks;
using CalculatorSample.Domain.V1.Models;
using CalculatorSample.Domain.V1.Repositories;
// ReSharper disable ClassNeverInstantiated.Global

namespace CalculatorSample.Domain.V1
{
    public sealed class CalculatorService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly ICalculationRecordsRepository _calculationRecordsRepository;
        
        public CalculatorService(
            IUsersRepository usersRepository, 
            ICalculationRecordsRepository calculationRecordsRepository)
        {
            _usersRepository = usersRepository;
            _calculationRecordsRepository = calculationRecordsRepository;
        }

        public async Task ExecuteCalculation(UserId userId, CalculationExpression expression)
        {
            var calculationResult = expression.Resolve();
            var calculationRecord = new CalculationRecord
            {
                Id = CalculationRecordId.New(),
                UserId = userId,
                Expression = expression,
                Result = calculationResult,
                DateCreated = DateTime.Now,
            };
            await _calculationRecordsRepository.Insert(calculationRecord);
            await _usersRepository.UpdateUserLastCalculationRecordId(userId, calculationRecord.Id);
        }
    }
}