using Microsoft.AspNetCore.Components;
using MyFinances.Blazor.Client.Services;
using MyFinances.Blazor.Shared.Origin;
using MyFinances.Blazor.Shared.Recurrence;
using System.Net.Http.Json;

namespace MyFinances.Blazor.Client.Pages.Recurrence
{
    public partial class Index
    {
        [Inject]
        private OriginService OriginService { get; set; }
        
        [Inject]
        private RecurrenceService RecurrenceService { get; set; }

        public List<RecurrenceDto> Recurrences = new List<RecurrenceDto>();
        public List<OriginDto> Origins { get; private set; } = new List<OriginDto>();

        protected override async Task OnInitializedAsync()
        {
            Recurrences = await RecurrenceService.ListAsync();

            await base.OnInitializedAsync();
        }
    }
}