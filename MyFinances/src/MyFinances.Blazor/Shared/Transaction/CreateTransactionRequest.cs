namespace MyFinances.Blazor.Shared.Transaction
{
    public class CreateTransactionRequest
    {
        public CreateTransactionRequest(string description,
                                        decimal value,
                                        DateTime estimatedDate,
                                        DateTime? confirmedDate,
                                        int categoryId,
                                        int originId)
        {
            Description = description;
            Value = value;
            EstimatedDate = estimatedDate;
            ConfirmedDate = confirmedDate;
            CategoryId = categoryId;
            OriginId = originId;
        }

        public string Description { get; set; }

        public decimal Value { get; set; }
        public DateTime EstimatedDate { get; set; }
        public DateTime? ConfirmedDate { get; set; }
        public int CategoryId { get; set; }
        public int OriginId { get; set; }
    }
}