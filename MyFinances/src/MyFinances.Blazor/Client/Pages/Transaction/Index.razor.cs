using MyFinances.Blazor.Shared;
using System.Text.Json;

namespace MyFinances.Blazor.Client.Pages.Transaction
{
    public partial class Index
    {
        public List<GetTransactionsInRangeResponse> transactions = new List<GetTransactionsInRangeResponse>();

        protected override async Task OnInitializedAsync()
        {
            HttpClient client = new HttpClient();
            using (client)
            {
                var response = await client.GetAsync("https://localhost:7073/api/Transaction?DateTimeRange.Start=10%20Jan%202022%2001%3A41%3A21%20GMT%20&DateTimeRange.End=13%20Jan%202022%2001%3A41%3A21%20GMT%20");
                var responseContent = await response.Content.ReadAsStreamAsync();

                var opt = new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };

                if(responseContent != null)
                    transactions = await JsonSerializer.DeserializeAsync<List<GetTransactionsInRangeResponse>>(responseContent, opt);
            }

            await base.OnInitializedAsync();
        }
    }
}
