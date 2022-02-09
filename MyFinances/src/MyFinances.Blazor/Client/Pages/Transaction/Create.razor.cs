using MyFinances.Blazor.Client.Models;
using MyFinances.Blazor.Shared.Transactions;
using System.Net.Http.Headers;
using System.Text.Json;

namespace MyFinances.Blazor.Client.Pages.Transaction
{
    public partial class Create
    {
        private TransactionCreate model = new();

        private  async Task HandleValidSubmit()
        {
            var requestModel = new CreateTransactionRequest()
            {
                EstimatedDate = model.EstimatedDate,
                Value = model.Value,
                ConfirmedDate = model.ConfirmedDate
            };

            HttpClient client = new HttpClient();
            using (client)
            {
                HttpContent httpContent = new StringContent(JsonSerializer.Serialize(requestModel));
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var response = await client.PostAsync("https://localhost:7073/api/Transaction", httpContent);

            }
        }
    }
}
