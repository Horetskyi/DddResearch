using System;
using System.Threading.Tasks;
using CalculatorSample.App.V0.DataLayer.Entities;
using CalculatorSample.App.V0.DataLayer.Repositories;
using CalculatorSample.Domain.V0;
using CalculatorSample.Domain.V0.Models;

namespace CalculatorSample.App.V0
{
    public sealed class CalculatorApi
    {
        private readonly CalculatorService _calculatorService;
        private readonly CalculatorState _calculatorState;
        private readonly IUsersRepository _usersRepository;
        private readonly ICalculationRecordsRepository _calculationRecordsRepository;
        
        public CalculatorApi(
            CalculatorService calculatorService,
            CalculatorState calculatorState,
            IUsersRepository usersRepository, 
            ICalculationRecordsRepository calculationRecordsRepository)
        {
            _calculatorService = calculatorService;
            _calculatorState = calculatorState;
            _usersRepository = usersRepository;
            _calculationRecordsRepository = calculationRecordsRepository;
        }

        public async Task Calculate(Guid userId, string calculationExpression)
        {
            var domainUserId = new UserId(userId);
            var domainCalculationExpression = new CalculationExpression(calculationExpression);
            var changes = _calculatorService.ExecuteCalculation(_calculatorState, domainUserId, domainCalculationExpression);
            await _usersRepository.UpdateUser(changes.User.MapToEntity());
            await _calculationRecordsRepository.InsertRecord(changes.Record.MapToEntity());
        }
    }
}