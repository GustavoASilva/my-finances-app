namespace MyFinances.Blazor.Shared.Transaction
{
    public class PatchTransactionRequest
    {
        public bool Confirmed { get; set; }

        public PatchTransactionRequest()
        {
        }

        public PatchTransactionRequest(bool confirmed)
        {
            Confirmed = confirmed;
        }
    }
}
