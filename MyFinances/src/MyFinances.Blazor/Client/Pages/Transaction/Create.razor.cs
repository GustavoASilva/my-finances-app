using Microsoft.AspNetCore.Components;
using MyFinances.Blazor.Client.Models;
using MyFinances.Blazor.Client.Services;
using MyFinances.Blazor.Shared.Origin;
using MyFinances.Blazor.Shared.Transaction;
using MyFinances.Core.SyncedAggregates;

namespace MyFinances.Blazor.Client.Pages.Transaction
{
    public partial class Create
    {
        [Inject]
        private OriginService OriginService { get; set; } = default!;

        [Inject]
        private TransactionService TransactionService { get; set; } = default!;

        [Inject]
        NavigationManager NavigationManager { get; set; } = default!;

        public TransactionCreateDto Model = new();
        public IEnumerable<OriginDto> Origins { get; private set; } = new List<OriginDto>();
        public IEnumerable<TransactionCategory> Categories { get; private set; } = new List<TransactionCategory>();

        protected override async Task OnInitializedAsync()
        {
            Categories = TransactionCategory.List();
            Origins = await OriginService.ListAsync();
        }

        private async Task HandleValidSubmitAsync()
        {
            CreateTransactionRequest requestModel = new(Model.Description,
                                                        Model.Value,
                                                        Model.EstimatedDate,
                                                        Model.ConfirmedDate,
                                                        Model.CategoryId,
                                                        Model.OriginId);

            TransactionDto? transaction = await TransactionService.CreateAsync(requestModel);
            if (transaction != null)
                NavigationManager.NavigateTo("/transaction");
        }
    }
}
