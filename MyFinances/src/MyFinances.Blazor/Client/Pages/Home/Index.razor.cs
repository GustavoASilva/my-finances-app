using Microsoft.AspNetCore.Components;
using MyFinances.Blazor.Client.Services;
using MyFinances.Blazor.Shared.Transaction;

namespace MyFinances.Blazor.Client.Pages.Home
{
    public partial class Index
    {
        [Inject]
        TransactionService TransactionService { get; set; } = default!;

        List<TransactionDto> Transactions = new();

        decimal ActualBalance = 0;
        decimal EstimatedBalance = 0;

        protected override async Task OnInitializedAsync()
        {
            Transactions = await TransactionService.ListAsync();

            foreach (TransactionDto transaction in Transactions)
            {
                if (transaction.ConfirmedDate != null)
                    ActualBalance += transaction.Value;

                EstimatedBalance += transaction.Value;
            }
        }
    }
}
