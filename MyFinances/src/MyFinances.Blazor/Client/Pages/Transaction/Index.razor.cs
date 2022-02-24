using Microsoft.AspNetCore.Components;
using MyFinances.Blazor.Shared.Origin;
using MyFinances.Blazor.Shared.Transaction;
using System.Net.Http.Json;
using System.Text.Json;

namespace MyFinances.Blazor.Client.Pages.Transaction
{
    public partial class Index
    {
        public List<ListTransactionsResponse> Transactions { get; private set; } = new List<ListTransactionsResponse>();
        public List<GetOriginsResponse> Origins { get; private set; } = new List<GetOriginsResponse>();

        [Inject]
        private HttpClient httpClient { get; set; }
 
        protected override async Task OnInitializedAsync()
        {
            var opt = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            var originsRequest =  httpClient.GetFromJsonAsync<List<GetOriginsResponse>>("Origins", opt);

            var transactionsResponse = await httpClient.GetFromJsonAsync<List<ListTransactionsResponse>>("Transactions?DateTimeRange.Start=10%20Jan%202021%2001%3A41%3A21%20GMT%20&DateTimeRange.End=13%20Jan%202023%2001%3A41%3A21%20GMT%20", opt);
            if (transactionsResponse != null)
                Transactions = transactionsResponse;

            var originsResponse = await originsRequest;
            if (originsResponse != null)
                Origins = originsResponse;

            await base.OnInitializedAsync();
        }
    }
}