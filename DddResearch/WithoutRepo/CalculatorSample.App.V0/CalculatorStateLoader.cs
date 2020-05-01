using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalculatorSample.App.V0.DataLayer.Entities;
using CalculatorSample.App.V0.DataLayer.Repositories;
using CalculatorSample.Domain.V0;
using CalculatorSample.Domain.V0.Models;

namespace CalculatorSample.App.V0
{
    public sealed class CalculatorStateLoader
    {
        private readonly CalculatorState _calculatorState;
        private readonly IUsersRepository _usersRepository;
        private readonly ICalculationRecordsRepository _calculationRecordsRepository;

        public CalculatorStateLoader(
            CalculatorState calculatorState,
            IUsersRepository usersRepository,
            ICalculationRecordsRepository calculationRecordsRepository)
        {
            _calculatorState = calculatorState;
            _usersRepository = usersRepository;
            _calculationRecordsRepository = calculationRecordsRepository;
        }

        public async Task StartAsync()
        {
            var userEntities = await _usersRepository.GetAll();
            var recordsEntities = await _calculationRecordsRepository.GetAll();

            var users = MapToDomain(userEntities, recordsEntities);
            
            _calculatorState.AddUsers(users);
        }

        private static List<User> MapToDomain(IEnumerable<UserEntity> userEntities, 
            IReadOnlyCollection<CalculationRecordEntity> recordsEntities)
        {
            var users = userEntities
                .Select(userEntity =>
                {
                    var userId = new UserId(userEntity.Id);
                    var user = new User(userId);
                    var records = recordsEntities
                        .Where(recordEntity => recordEntity.UserId == userId)
                        .Select(recordEntity => recordEntity.MapToDomain())
                        .ToList();
                    user.AddCalculationRecords(records);
                    return user;
                })
                .ToList();
            return users;
        }
    }
}