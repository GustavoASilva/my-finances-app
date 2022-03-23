using Microsoft.AspNetCore.Components;
using MyFinances.Blazor.Client.Models;
using MyFinances.Blazor.Client.Services;
using MyFinances.Blazor.Shared.Origin;
using MyFinances.Blazor.Shared.Recurrence;
using System.Net.Http.Json;
using System.Text.Json;

namespace MyFinances.Blazor.Client.Pages.Recurrence
{
    public partial class Create
    {
        [Inject]
        private OriginService OriginService { get; set; }

        [Inject]
        private RecurrenceService RecurrenceService { get; set; }

        [Inject]
        private NavigationManager navigationManager { get; set; }


        public RecurrenceCreate Model = new RecurrenceCreate();
        public List<OriginDto> Origins { get; private set; } = new List<OriginDto>();

        protected override async Task OnInitializedAsync()
        {
            Origins = await OriginService.ListAsync();
        }

        private async Task HandleValidSubmitAsync()
        {
            var requestModel = new CreateRecurrenceRequest()
            {
                Start = Model.Start.Value,
                End = Model.End.Value,
                Value = Model.Value,
                DaysInterval = Model.DaysInterval,
                Name = Model.Name,
                TransactionCategory = Model.TransactionCategory,
                OriginId = Model.OriginId,
            };

            var createdDto = await RecurrenceService.CreateAsync(requestModel);
            if (createdDto != null)
                navigationManager.NavigateTo("/recurrence");

        }
    }
}
