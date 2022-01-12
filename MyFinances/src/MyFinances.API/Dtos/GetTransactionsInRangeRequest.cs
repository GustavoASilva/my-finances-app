using MyFinances.Core.ValueObjects;

namespace MyFinances.API.Dtos
{
    public class GetTransactionsInRangeRequest
    {
        public DateTimeRange DateTimeRange { get; set; }
    }
}
