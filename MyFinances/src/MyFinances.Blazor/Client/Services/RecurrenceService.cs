using MyFinances.Blazor.Shared.Recurrence;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace MyFinances.Blazor.Client.Services
{
    public class RecurrenceService
    {
        private static string Resource = "recurrences";
        private readonly HttpClient _httpClient;

        public RecurrenceService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<List<RecurrenceDto>> ListAsync()
        {
            List<RecurrenceDto> result = new List<RecurrenceDto>();

            var response = await _httpClient.GetFromJsonAsync<ListRecurrencesResponse>(Resource);

            if (response != null)
                result = response.Recurrences;

            return result;
        }

        public async Task<RecurrenceDto?> CreateAsync(CreateRecurrenceRequest request)
        {
            RecurrenceDto? result = null;

            var response = await _httpClient.PostAsJsonAsync(Resource, request);

            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadFromJsonAsync<RecurrenceDto>();

            return result;
        }

        public async Task DeleteAsync(Guid id)
        {
            await _httpClient.DeleteAsync($"{Resource}/{id}");
        }
    }
}
