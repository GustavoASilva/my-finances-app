using MyFinances.Blazor.Client.Repositories;
using MyFinances.Blazor.Shared.Recurrence;

namespace MyFinances.Blazor.Client.Services
{
    public class RecurrenceService
    {
        private readonly IMyFinancesApi _myFinancesApi;

        public RecurrenceService(IMyFinancesApi myFinancesApi)
        {
            _myFinancesApi = myFinancesApi;
        }

        public async Task<List<RecurrenceDto>> ListAsync()
        {
            List<RecurrenceDto> result = new();

            var response = await _myFinancesApi.GetRecurrencesAsync();

            if (response != null)
                result = response.Recurrences;

            return result;
        }

        public async Task<bool> CreateAsync(CreateRecurrenceRequest request)
        {
            var response = await _myFinancesApi.PostRecurrenceAsync(request);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var response = await _myFinancesApi.DeleteRecurrenceAsync(id);
            return response.IsSuccessStatusCode;
        }
    }
}
