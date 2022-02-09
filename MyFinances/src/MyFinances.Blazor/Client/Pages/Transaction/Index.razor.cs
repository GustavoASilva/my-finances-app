using MyFinances.Blazor.Shared.Transactions;
using System.Net.Http.Json;
using System.Text.Json;

namespace MyFinances.Blazor.Client.Pages.Transaction
{
    public partial class Index
    {
        public List<GetTransactionsInRangeResponse> transactions = new List<GetTransactionsInRangeResponse>();
        private readonly HttpClient _httpClient;

        public Index(HttpClient httpClient) : base()
        {
            _httpClient = httpClient;
        }

        protected override async Task OnInitializedAsync()
        {

            var opt = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            transactions = await _httpClient.GetFromJsonAsync<List<GetTransactionsInRangeResponse>>("https://localhost:8080/api/Transactions?DateTimeRange.Start=10%20Jan%202022%2001%3A41%3A21%20GMT%20&DateTimeRange.End=13%20Jan%202022%2001%3A41%3A21%20GMT%20", opt);

            await base.OnInitializedAsync();
        }
    }
}