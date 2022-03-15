using Microsoft.AspNetCore.Components;
using MyFinances.Blazor.Client.Models;
using MyFinances.Blazor.Client.Services;
using MyFinances.Blazor.Shared.Origin;
using MyFinances.Blazor.Shared.Transaction;
using System.Net.Http.Headers;
using System.Text.Json;

namespace MyFinances.Blazor.Client.Pages.Transaction
{
    public partial class Create
    {
        [Inject]
        private OriginService OriginService { get; set; }

        [Inject]
        private TransactionService TransactionService { get; set; }

        public TransactionCreate Model = new();
        public List<OriginDto> Origins { get; private set; } = new List<OriginDto>();

        protected override async Task OnInitializedAsync()
        {
            Origins = await OriginService.ListAsync();
        }

        private async Task HandleValidSubmitAsync()
        {
            var requestModel = new CreateTransactionRequest()
            {
                EstimatedDate = Model.EstimatedDate,
                Value = Model.Value,
                ConfirmedDate = Model.ConfirmedDate,
                OriginId = Model.OriginId,
                Description = Model.Description
            };

            await TransactionService.CreateAsync(requestModel);
        }
    }
}
