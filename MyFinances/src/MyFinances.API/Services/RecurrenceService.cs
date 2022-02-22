using MyFinances.Core.Interfaces;
using MyFinances.Core.SyncedAggregates;

namespace MyFinances.API.Services
{
    public class RecurrenceService : IRecurrenceService
    {
        private readonly IRepository<Recurrence> _recurrenceRepository;

        public RecurrenceService(IRepository<Recurrence> recurrenceRepository)
        {
            _recurrenceRepository = recurrenceRepository ?? throw new ArgumentNullException(nameof(recurrenceRepository));
        }

        public async Task ApplyRecurrences()
        {
            //Apply specification to fetch only active recurrences
            var recurrences = await _recurrenceRepository.ListAsync();

            foreach (var recurrence in recurrences)
            {
                recurrence.Apply();
                await _recurrenceRepository.UpdateAsync(recurrence);
            }
        }
    }
}