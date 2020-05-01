namespace CalculatorSample.Domain.V1.Models
{
    public sealed class User
    {
        public UserId Id { get; }
        public CalculationRecordId LastCalculationRecordId { get; set; }

        public User(UserId id)
        {
            Id = id;
        }
    }
}