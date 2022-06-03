using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MyFinances.Blazor.Client;
using MyFinances.Blazor.Client.Repositories;
using MyFinances.Blazor.Client.Services;
using Refit;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var apiUrl = builder.Configuration.GetValue<string>("API_URL");

builder.Services
    .AddRefitClient<IMyFinancesApi>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri(apiUrl));

builder.Services.AddScoped<OriginService>();
builder.Services.AddScoped<TransactionService>();
builder.Services.AddScoped<RecurrenceService>();

await builder.Build().RunAsync();