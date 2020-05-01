using System;

namespace CalculatorSample.App.V0.DataLayer.Entities
{
    public sealed class UserEntity
    {
        public Guid Id { get; set; }
        public Guid LastCalculatedRecordId { get; set; }
    }
}