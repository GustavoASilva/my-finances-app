using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MyFinances.Blazor.Client;
using MyFinances.Blazor.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://myfinancesapi.azurewebsites.net/api/") });

builder.Services.AddScoped<OriginService>();
builder.Services.AddScoped<TransactionService>();
builder.Services.AddScoped<RecurrenceService>();

await builder.Build().RunAsync();
