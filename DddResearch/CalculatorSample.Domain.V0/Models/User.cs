using System.Collections.Generic;
using System.Linq;

namespace CalculatorSample.Domain.V0.Models
{
    public sealed class User
    {
        private readonly List<CalculationRecord> _calculationHistory = new List<CalculationRecord>();
        
        public UserId Id { get; }
        public CalculationRecordId LastCalculationRecordId { get; private set; }
        public IReadOnlyCollection<CalculationRecord> CalculationHistory => _calculationHistory;

        public User(UserId id)
        {
            Id = id;
        }

        public void AddCalculationRecord(CalculationRecord calculationRecord)
        {
            _calculationHistory.Add(calculationRecord);
            LastCalculationRecordId = calculationRecord.Id;
        }

        public void AddCalculationRecords(List<CalculationRecord> records)
        {
            _calculationHistory.AddRange(records);
            LastCalculationRecordId = GetLastCalculatedRecord().Id;
        }

        private CalculationRecord GetLastCalculatedRecord()
        {
            var lastCreated = _calculationHistory.Max(x => x.DateCreated);
            return _calculationHistory.First(x => x.DateCreated == lastCreated);
        }
    }
}