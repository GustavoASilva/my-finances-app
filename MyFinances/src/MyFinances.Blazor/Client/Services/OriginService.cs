using MyFinances.Blazor.Client.Repositories;
using MyFinances.Blazor.Shared.Origin;

namespace MyFinances.Blazor.Client.Services
{
    public class OriginService
    {
        private readonly IMyFinancesApi _myFinancesApi;

        public OriginService(IMyFinancesApi myFinancesApi)
        {
            _myFinancesApi = myFinancesApi;
        }

        public async Task<List<OriginDto>> ListAsync()
        {
            List<OriginDto> result = new();

            var response = await _myFinancesApi.GetOriginsAsync();

            if (response != null)
                result = response.Origins;

            return result;
        }

        public async Task<bool> CreateAsync(CreateOriginRequest request)
        {
            var response = await _myFinancesApi.PostOriginAsync(request);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _myFinancesApi.DeleteOriginAsync(id);
            return response.IsSuccessStatusCode;
        }
    }
}