using Microsoft.AspNetCore.Components;
using MyFinances.Blazor.Client.Models;
using MyFinances.Blazor.Client.Services;
using MyFinances.Blazor.Shared.Origin;
using MyFinances.Blazor.Shared.Transaction;
using MyFinances.Core.SyncedAggregates;
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

        [Inject]
        NavigationManager NavManager { get; set; }

        public TransactionCreateDto Model = new();
        public IEnumerable<OriginDto> Origins { get; private set; } = new List<OriginDto>();
        public IEnumerable<Category> Categories { get; private set; } = new List<Category>();

        protected override async Task OnInitializedAsync()
        {
            Origins = await OriginService.ListAsync();
            Categories = Category.List();
        }

        private async Task HandleValidSubmitAsync()
        {
            var requestModel = new CreateTransactionRequest()   
            {
                EstimatedDate = Model.EstimatedDate,
                Value = Model.Value,
                ConfirmedDate = Model.ConfirmedDate,
                OriginId = Model.OriginId,
                Description = Model.Description,
                CategoryId = Model.CategoryId
            };

            
            TransactionDto? transaction = await TransactionService.CreateAsync(requestModel);
            if(transaction != null)
                NavManager.NavigateTo("/transaction");
        }
    }
}
