using System.Collections.Generic;
using System.Threading.Tasks;
using CalculatorSample.App.V0.DataLayer.Entities;

namespace CalculatorSample.App.V0.DataLayer.Repositories
{
    public interface ICalculationRecordsRepository
    {
        Task InsertRecord(CalculationRecordEntity record);
        Task<List<CalculationRecordEntity>> GetAll();
    }
}