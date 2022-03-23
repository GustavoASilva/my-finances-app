using ChartJs.Blazor.Common;
using ChartJs.Blazor.PieChart;
using ChartJs.Blazor.Util;
using Microsoft.AspNetCore.Components;
using MyFinances.Blazor.Client.Services;
using MyFinances.Blazor.Shared.Transaction;

namespace MyFinances.Blazor.Client.Pages.Home
{
    public partial class Index
    {
        [Inject]
        TransactionService TransactionService { get; set; }

        List<TransactionDto> Transactions = new List<TransactionDto>();

        decimal ActualBalance = 0;
        decimal EstimatedBalance = 0;

        protected override async Task OnInitializedAsync()
        {
            Transactions = await TransactionService.ListAsync();

            foreach (TransactionDto transaction in Transactions)
            {
                if (transaction.ConfirmedDate != null)
                    ActualBalance += transaction.Value;
                else
                    EstimatedBalance += transaction.Value;
            }
        }
    }
}
