using Microsoft.AspNetCore.Components;
using MyFinances.Blazor.Client.Models;
using MyFinances.Blazor.Client.Services;
using MyFinances.Blazor.Shared.Origin;
using MyFinances.Blazor.Shared.Recurrence;
using MyFinances.Core.SyncedAggregates;

namespace MyFinances.Blazor.Client.Pages.Recurrence
{
    public partial class Create
    {
        [Inject]
        private OriginService OriginService { get; set; } = default!;

        [Inject]
        private RecurrenceService RecurrenceService { get; set; } = default!;

        [Inject]
        private NavigationManager NavigationManager { get; set; } = default!;


        public RecurrenceCreateDto Model = new();
        public IEnumerable<OriginDto> Origins = new List<OriginDto>();
        public IEnumerable<TransactionCategory> Categories = new List<TransactionCategory>();

        protected override async Task OnInitializedAsync()
        {
            Categories = TransactionCategory.List();
            Origins = await OriginService.ListAsync();
        }

        private async Task HandleValidSubmitAsync()
        {
            var requestModel = new CreateRecurrenceRequest()
            {
                Start = Model.Start!.Value,
                End = Model.End!.Value,
                Value = Model.Value,
                DaysInterval = Model.DaysInterval,
                Name = Model.Name,
                TransactionCategoryId = Model.TransactionCategoryId,
                OriginId = Model.OriginId,
            };

            bool created = await RecurrenceService.CreateAsync(requestModel);

            if (created)
                NavigationManager.NavigateTo("/recurrence");
        }
    }
}
