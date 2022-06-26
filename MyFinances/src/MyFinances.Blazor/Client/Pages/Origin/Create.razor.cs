using Microsoft.AspNetCore.Components;
using MyFinances.Blazor.Client.Models;
using MyFinances.Blazor.Client.Services;
using MyFinances.Blazor.Shared.Origin;

namespace MyFinances.Blazor.Client.Pages.Origin
{
    public partial class Create
    {
        [Inject]
        OriginService OriginService { get; set; } = default!;

        [Inject]
        NavigationManager NavigationManager { get; set; } = default!;

        OriginCreateDto Model = new();

        private async Task HandleValidSubmit()
        {
            var createRequest = new CreateOriginRequest(Model.Alias);

            bool created = await OriginService.CreateAsync(createRequest);

            if (created)
                NavigationManager.NavigateTo("/origin");
        }
    }
}