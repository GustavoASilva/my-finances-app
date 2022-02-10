using Microsoft.AspNetCore.Components;
using MyFinances.Blazor.Client.Models;
using MyFinances.Blazor.Shared.Origins;
using MyFinances.Blazor.Shared.Transactions;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace MyFinances.Blazor.Client.Pages.Transaction
{
    public partial class Create
    {
        [Inject]
        public HttpClient httpClient { get; private set; }

        public TransactionCreate model = new();
        public List<GetOriginsResponse> origins { get; private set; } = new List<GetOriginsResponse>();

        protected override async Task OnInitializedAsync()
        {
            var opt = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            var originsResponse = await httpClient.GetFromJsonAsync<List<GetOriginsResponse>>("Origins", opt);
            if (originsResponse != null)
                origins = originsResponse;

        }


        private async Task HandleValidSubmit()
        {
            var requestModel = new CreateTransactionRequest()
            {
                EstimatedDate = model.EstimatedDate,
                Value = model.Value,
                ConfirmedDate = model.ConfirmedDate,
                OriginId = model.OriginId,
                Description = model.Description
            };

            HttpContent httpContent = new StringContent(JsonSerializer.Serialize(requestModel));
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await httpClient.PostAsync("Transactions", httpContent);

        }
    }
}
