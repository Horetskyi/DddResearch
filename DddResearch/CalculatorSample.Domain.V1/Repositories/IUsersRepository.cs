using System.Threading.Tasks;
using CalculatorSample.Domain.V1.Models;

namespace CalculatorSample.Domain.V1.Repositories
{
    public interface IUsersRepository
    {
        Task UpdateUserLastCalculationRecordId(UserId userId, CalculationRecordId lastCalculationRecordId);
    }
}