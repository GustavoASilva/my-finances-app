using Microsoft.AspNetCore.Components;
using MyFinances.Blazor.Client.Services;
using MyFinances.Blazor.Shared.Recurrence;

namespace MyFinances.Blazor.Client.Pages.Recurrence
{
    public partial class Index
    {
        [Inject]
        private RecurrenceService RecurrenceService { get; set; } = default!;
        public List<RecurrenceDto> Recurrences = new();

        protected override async Task OnInitializedAsync()
        {
            await LoadRecurrencesAsync();
            Recurrences = await RecurrenceService.ListAsync();
        }

        private async Task LoadRecurrencesAsync()
        {
            Recurrences = await RecurrenceService.ListAsync();
        }

        protected async Task Delete(Guid id)
        {
            await RecurrenceService.DeleteAsync(id);
            await LoadRecurrencesAsync();
        }
    }
}