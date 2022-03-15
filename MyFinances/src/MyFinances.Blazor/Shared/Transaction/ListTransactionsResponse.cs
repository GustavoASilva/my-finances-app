namespace MyFinances.Blazor.Shared.Transaction
{
    public class ListTransactionsResponse
    {
        public ListTransactionsResponse(List<TransactionDto> transactions)
        {
            Transactions = transactions;
        }

        public List<TransactionDto> Transactions { get; set; }

    }
}
