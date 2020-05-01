using System.Collections.Generic;
using System.Threading.Tasks;
using CalculatorSample.App.V0.DataLayer.Entities;

namespace CalculatorSample.App.V0.DataLayer.Repositories
{
    public interface IUsersRepository
    {
        Task UpdateUser(UserEntity user);
        Task<List<UserEntity>> GetAll();
    }
}