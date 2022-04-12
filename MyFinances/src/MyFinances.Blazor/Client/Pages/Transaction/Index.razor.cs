﻿using Microsoft.AspNetCore.Components;
using MyFinances.Blazor.Client.Services;
using MyFinances.Blazor.Shared.Transaction;

namespace MyFinances.Blazor.Client.Pages.Transaction
{
    public partial class Index
    {
        [Inject]
        TransactionService TransactionService { get; set; }

        List<TransactionDto> Transactions { get; set; } = new List<TransactionDto>();

        protected override async Task OnInitializedAsync()
        {
            await LoadTransactionsAsync();

            await base.OnInitializedAsync();
        }

        protected async Task Delete(Guid id)
        {
            await TransactionService.DeleteAsync(id);
            await LoadTransactionsAsync();
        }

        protected async Task Confirm(Guid id)
        {
            var patchTransaction = new PatchTransactionRequest(true);
            await TransactionService.PatchAsync(id, patchTransaction);
            await LoadTransactionsAsync();
        }

        private async Task LoadTransactionsAsync()
        {
            Transactions = await TransactionService.ListAsync();
        }
    }
}