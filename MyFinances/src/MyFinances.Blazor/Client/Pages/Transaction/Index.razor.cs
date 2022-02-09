using Microsoft.AspNetCore.Components;
using MyFinances.Blazor.Shared.Transactions;
using System.Net.Http.Json;
using System.Text.Json;

namespace MyFinances.Blazor.Client.Pages.Transaction
{
    public partial class Index
    {
        public List<GetTransactionsInRangeResponse> transactions = new List<GetTransactionsInRangeResponse>();

        [Inject]
        public HttpClient httpClient { get; private set; }

        protected override async Task OnInitializedAsync()
        {

            var opt = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            var transactionsResponse = await httpClient.GetFromJsonAsync<List<GetTransactionsInRangeResponse>>("Transactions?DateTimeRange.Start=10%20Jan%202022%2001%3A41%3A21%20GMT%20&DateTimeRange.End=13%20Jan%202023%2001%3A41%3A21%20GMT%20", opt);
            if (transactionsResponse != null)
                transactions = transactionsResponse;

            await base.OnInitializedAsync();
        }
    }
}