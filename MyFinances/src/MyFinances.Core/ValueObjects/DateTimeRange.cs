namespace MyFinances.Core.ValueObjects
{
    public class DateTimeRange : ValueObject
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public bool IsInRange(DateTime date)
        {
            return date >= Start && date <= End;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Start;
            yield return End;
        }
    }
}
