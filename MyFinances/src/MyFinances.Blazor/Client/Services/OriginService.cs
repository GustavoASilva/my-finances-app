using MyFinances.Blazor.Shared.Origin;
using System.Net.Http.Json;

namespace MyFinances.Blazor.Client.Services
{
    public class OriginService
    {
        private static string Resource = "origins";
        private readonly HttpClient _httpClient;

        public OriginService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<List<OriginDto>> ListAsync()
        {
            List<OriginDto> result = new List<OriginDto>();

            var response = await _httpClient.GetFromJsonAsync<ListOriginsResponse>(Resource);

            if (response != null)
                result = response.Origins;

            return result;
        }

        public async Task<OriginDto?> CreateAsync(CreateOriginRequest request)
        {
            OriginDto? result = null;

            var response = await _httpClient.PostAsJsonAsync(Resource, request);

            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadFromJsonAsync<OriginDto>();

            return result;
        }
    }
}