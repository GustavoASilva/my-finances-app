using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

namespace MyFinances.Blazor.Client
{
    public class CustomAuthorizationMessageHandler : AuthorizationMessageHandler
    {
        public CustomAuthorizationMessageHandler(IAccessTokenProvider provider,
            NavigationManager navigationManager, 
            IConfiguration configuration)
            : base(provider, navigationManager)
        {
            var apiUrl = configuration.GetValue<string>("API_URL");

            ConfigureHandler(
                authorizedUrls: new[] { apiUrl },
                scopes: new[] { "api://5e064a37-77e5-4456-ad30-d6070c440614/System.FullAccess" }
);
        }
    }
}
