using Microsoft.AspNetCore.Components;
using MyFinances.Blazor.Client.Services;
using MyFinances.Blazor.Shared.Origin;
using System.Net.Http.Json;
using System.Text.Json;

namespace MyFinances.Blazor.Client.Pages.Origin
{
    public partial class Index
    {
        [Inject]
        OriginService OriginService { get; set; }

        List<OriginDto> Origins { get; set; } = new List<OriginDto>();

        protected override async Task OnInitializedAsync()
        {
            Origins = await OriginService.ListAsync();
        }
    }
}