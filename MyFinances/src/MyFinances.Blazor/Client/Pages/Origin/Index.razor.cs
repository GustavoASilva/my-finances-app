using Microsoft.AspNetCore.Components;
using MyFinances.Blazor.Client.Services;
using MyFinances.Blazor.Shared.Origin;

namespace MyFinances.Blazor.Client.Pages.Origin
{
    public partial class Index
    {
        [Inject]
        OriginService OriginService { get; set; } = default!;

        List<OriginDto> Origins { get; set; } = new List<OriginDto>();

        protected override async Task OnInitializedAsync()
        {
            await LoadOriginsAsync();
        }

        protected async Task Delete(int id)
        {
            await OriginService.DeleteAsync(id);
            await LoadOriginsAsync();
        }

        private async Task LoadOriginsAsync()
        {
            Origins = await OriginService.ListAsync();
        }
    }
}