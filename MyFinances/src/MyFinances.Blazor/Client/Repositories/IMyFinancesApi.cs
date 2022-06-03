using MyFinances.Blazor.Shared.Origin;
using MyFinances.Blazor.Shared.Recurrence;
using MyFinances.Blazor.Shared.Transaction;
using Refit;

namespace MyFinances.Blazor.Client.Repositories
{
    public interface IMyFinancesApi
    {
        [Get("/origins")]
        Task<ListOriginsResponse> GetOriginsAsync();

        [Post("/origins")]
        Task<HttpResponseMessage> PostOriginAsync([Body] CreateOriginRequest createOrigin);

        [Delete("/origins/{id}")]
        Task<HttpResponseMessage> DeleteOriginAsync(int id);

        [Get("/recurrences")]
        Task<ListRecurrencesResponse> GetRecurrencesAsync();

        [Post("/recurrences")]
        Task<HttpResponseMessage> PostRecurrenceAsync([Body] CreateRecurrenceRequest createRecurrence);

        [Delete("/recurrences/{id}")]
        Task<HttpResponseMessage> DeleteRecurrenceAsync(Guid id);

        [Get("/transactions")]
        Task<ListTransactionsResponse> GetTransactionsAsync();

        [Post("/transactions")]
        Task<HttpResponseMessage> PostTransactionAsync([Body] CreateTransactionRequest createTransaction);

        [Patch("/transactions/{id}")]
        Task<HttpResponseMessage> PatchTransactionAsync(Guid id, [Body] PatchTransactionRequest patchTransaction);

        [Delete("/transactions/{id}")]
        Task<HttpResponseMessage> DeleteTransactionAsync(Guid id);
    }
}
