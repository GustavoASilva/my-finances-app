using MyFinances.Blazor.Shared.Transaction;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace MyFinances.Blazor.Client.Services
{
    public class TransactionService
    {
        private static string Resource = "transactions";
        private readonly HttpClient _httpClient;

        public TransactionService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<List<TransactionDto>> ListAsync()
        {
            List<TransactionDto> result = new List<TransactionDto>();

            var response = await _httpClient.GetFromJsonAsync<ListTransactionsResponse>(Resource);

            if (response != null)
                result = response.Transactions;

            return result;
        }

        public async Task<TransactionDto?> CreateAsync(CreateTransactionRequest request)
        {
            TransactionDto? result = null;

            var response = await _httpClient.PostAsJsonAsync(Resource, request);

            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadFromJsonAsync<TransactionDto>();

            return result;
        }

        public async Task DeleteAsync(Guid id)
        {
            await _httpClient.DeleteAsync($"{Resource}/{id}");
        }

        public async Task PatchAsync(Guid id, PatchTransactionRequest request)
        {

            var jsonRequest = JsonContent.Create(request);


            await _httpClient.PatchAsync($"{Resource}/{id}", jsonRequest);
        }
    }
}
