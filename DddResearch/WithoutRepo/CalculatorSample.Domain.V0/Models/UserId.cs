using System;

namespace CalculatorSample.Domain.V0.Models
{
    public readonly struct UserId
    {
        public Guid Guid { get; }

        public UserId(Guid guid)
        {
            Guid = guid;
        }

        public static implicit operator Guid(UserId id) => id.Guid;
    }
}