using MyFinances.Blazor.Shared;
using System.Text.Json;

namespace MyFinances.Blazor.Client.Pages
{
    public partial class Index
    {
        public List<TransactionDto> transactions = new List<TransactionDto>();

        protected override async Task OnInitializedAsync()
        {
            HttpClient client = new HttpClient();
            using(client)
            {
                var response = await client.GetAsync("https://localhost:7073/api/Transaction?householdId=1");
                var responseContent = await response.Content.ReadAsStreamAsync();

                var opt = new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };

                transactions = await JsonSerializer.DeserializeAsync<List<TransactionDto>>(responseContent, opt);
            }

            await base.OnInitializedAsync();
        }
    }
}