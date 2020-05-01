using System.Collections.Generic;
using System.Threading.Tasks;
using CalculatorSample.Domain.V1.Models;

namespace CalculatorSample.Domain.V1.Repositories
{
    public interface ICalculationRecordsRepository
    {
        Task Insert(CalculationRecord calculationRecord);
        Task<List<CalculationRecord>> GetCalculationHistory(UserId userId);
    }
}