using System;
using System.Threading.Tasks;
using CalculatorSample.Domain.V1;
using CalculatorSample.Domain.V1.Models;

namespace CalculatorSample.App.V1
{
    public sealed class CalculatorApi
    {
        private readonly CalculatorService _calculatorService;

        public CalculatorApi(CalculatorService calculatorService)
        {
            _calculatorService = calculatorService;
        }

        public async Task Calculate(Guid userId, string calculationExpression)
        {
            var domainUserId = new UserId(userId);
            var domainCalculationExpression = new CalculationExpression(calculationExpression);
            await _calculatorService.ExecuteCalculation(domainUserId, domainCalculationExpression);
        }
    }
}