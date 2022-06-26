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

            /// TODO: Calculate balance in another endpoint or service

            ActualBalance = Transactions
                .Where(t => t.ConfirmedDate is not null)
                .Sum(t => t.Value);
            
            var today = DateTime.Now;

            EstimatedBalance = Transactions
                .Where(t => t.EstimatedDate.Month == today.Month
                            && t.EstimatedDate.Year == today.Year)
                .Sum(t => t.Value);
        }
    }
}