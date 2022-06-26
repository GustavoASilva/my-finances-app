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
builder.Services.AddScoped<CustomAuthorizationMessageHandler>();

builder.Services
    .AddRefitClient<IMyFinancesApi>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri(apiUrl))
    .AddHttpMessageHandler<CustomAuthorizationMessageHandler>();

builder.Services.AddScoped<OriginService>();
builder.Services.AddScoped<TransactionService>();
builder.Services.AddScoped<RecurrenceService>();


builder.Services.AddMsalAuthentication(options =>
{
    builder.Configuration.Bind("AzureAd", options.ProviderOptions.Authentication);
    options.ProviderOptions.DefaultAccessTokenScopes.Add("api://5e064a37-77e5-4456-ad30-d6070c440614/System.FullAccess");
    options.ProviderOptions.LoginMode = "redirect";
});

builder.Services.AddApiAuthorization();


await builder.Build().RunAsync();