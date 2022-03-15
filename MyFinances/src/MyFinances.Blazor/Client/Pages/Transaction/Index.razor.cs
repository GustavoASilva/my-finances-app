using Microsoft.AspNetCore.Components;
using MyFinances.Blazor.Client.Services;
using MyFinances.Blazor.Shared.Origin;
using MyFinances.Blazor.Shared.Transaction;
using System.Net.Http.Json;

namespace MyFinances.Blazor.Client.Pages.Transaction
{
    public partial class Index
    {
        [Inject]
        OriginService OriginService { get; set; }

        [Inject]
        TransactionService TransactionService { get; set; }

        [Inject]
        NavigationManager NavManager { get; set; }

        List<TransactionDto> Transactions { get;  set; } = new List<TransactionDto>();
        List<OriginDto> Origins { get;  set; } = new List<OriginDto>();

        protected override async Task OnInitializedAsync()
        {
            Origins = await OriginService.ListAsync();
            Transactions = await TransactionService.ListAsync();

            await base.OnInitializedAsync();
        }

        protected async Task DeleteAsync(Guid id)
        {
            await TransactionService.DeleteAsync(id);
            Transactions.RemoveAll(t => t.Id == id);
        }

        protected async Task ConfirmAsync(Guid id)
        {
            var patchTransaction = new PatchTransactionRequest(true);
            await TransactionService.PatchAsync(id, patchTransaction);
            
            InvokeAsync(() =>
            {

                StateHasChanged();
            });
        }
    }
}