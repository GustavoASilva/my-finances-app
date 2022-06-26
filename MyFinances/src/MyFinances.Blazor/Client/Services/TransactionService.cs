using MyFinances.Blazor.Client.Repositories;
using MyFinances.Blazor.Shared.Transaction;

namespace MyFinances.Blazor.Client.Services
{
    public class TransactionService
    {
        private readonly IMyFinancesApi _myFinancesApi;

        public TransactionService(IMyFinancesApi myFinancesApi)
        {
            _myFinancesApi = myFinancesApi;
        }

        public async Task<List<TransactionDto>> ListAsync()
        {
            List<TransactionDto> result = new List<TransactionDto>();

            var response = await _myFinancesApi.GetTransactionsAsync();

            if (response != null)
                result = response.Transactions;

            return result;
        }

        public async Task<bool> CreateAsync(CreateTransactionRequest request)
        {
            var response = await _myFinancesApi.PostTransactionAsync(request);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> PatchAsync(Guid id, PatchTransactionRequest request)
        {
            var response = await _myFinancesApi.PatchTransactionAsync(id, request);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var response = await _myFinancesApi.DeleteTransactionAsync(id);
            return response.IsSuccessStatusCode;
        }
    }
}
