using System.Collections.Generic;
using CalculatorSample.Domain.V0.Models;

namespace CalculatorSample.Domain.V0
{
    public sealed class CalculatorState
    {
        private readonly Dictionary<UserId, User> _users = new Dictionary<UserId, User>();

        public void AddUsers(IEnumerable<User> users)
        {
            foreach (var user in users)
                _users.Add(user.Id, user);
        }

        public User GetUser(in UserId userId)
        {
            return _users[userId];
        }
    }
}