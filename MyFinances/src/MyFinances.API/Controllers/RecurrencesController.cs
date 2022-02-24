using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyFinances.Blazor.Shared.Recurrence;
using MyFinances.Core.Interfaces;
using MyFinances.Core.SyncedAggregates;

namespace MyFinances.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecurrencesController : ControllerBase
    {
        private readonly IRepository<Recurrence> _recurrenceRepository;
        private IMapper _mapper;

        public RecurrencesController(IRepository<Recurrence> RecurrenceRepository, IMapper mapper)
        {
            _recurrenceRepository = RecurrenceRepository ?? throw new ArgumentNullException(nameof(RecurrenceRepository));
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var recurrences = await _recurrenceRepository.ListAsync();
            var response = new ListRecurrencesResponse();

            var mappedDtos = _mapper.Map<List<RecurrenceDto>>(recurrences);

            response.Recurrences = mappedDtos;

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateRecurrenceRequest recurrence)
        {
            var householdId = 1;
            var toModel = new Recurrence(recurrence.StartDate, recurrence.DaysInterval, recurrence.Value, recurrence.Category, recurrence.Description, householdId, recurrence.OriginId);

            var created = await _recurrenceRepository.AddAsync(toModel);

            await _recurrenceRepository.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), created);
        }

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete([FromRoute] int id)
        //{
        //    var Recurrence = await _recurrenceRepository.GetByIdAsync(id);

        //    if (Recurrence == null)
        //        return NotFound();

        //    await _recurrenceRepository.DeleteAsync(Recurrence);

        //    return NoContent();
        //}
    }
}
