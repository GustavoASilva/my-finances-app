using Microsoft.AspNetCore.Components;
using MyFinances.Blazor.Client.Models;
using MyFinances.Blazor.Client.Services;
using MyFinances.Blazor.Shared.Origin;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace MyFinances.Blazor.Client.Pages.Origin
{

    public partial class Create
    {
        [Inject]
        OriginService OriginService { get; set; }

        [Inject]
        NavigationManager NavManager { get; set; }

        OriginCreateDto Model = new();

        private async Task HandleValidSubmit()
        {
            var createRequest = new CreateOriginRequest(Model.Alias);

            OriginDto? origin = await OriginService.CreateAsync(createRequest);

            if (origin != null)
                NavManager.NavigateTo("/origin");
        }
    }
}