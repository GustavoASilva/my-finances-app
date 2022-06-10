using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyFinances.Blazor.Shared.Recurrence;
using MyFinances.Core.Interfaces;
using MyFinances.Core.SyncedAggregates;

namespace MyFinances.API.Controllers
{
    [Authorize]
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
        public async Task<ActionResult<ListRecurrencesResponse>> Get()
        {
            var recurrences = await _recurrenceRepository.ListAsync();
            var response = new ListRecurrencesResponse();

            var mappedDtos = _mapper.Map<List<RecurrenceDto>>(recurrences);

            response.Recurrences = mappedDtos;

            return response;
        }

        [HttpPost]
        public async Task<ActionResult<RecurrenceDto>> Post([FromBody] CreateRecurrenceRequest recurrence)
        {
            var householdId = 1;
            var toModel = new Recurrence(DateOnly.FromDateTime(recurrence.Start),
                                         DateOnly.FromDateTime(recurrence.End),
                                         recurrence.DaysInterval,
                                         recurrence.Value,
                                         recurrence.TransactionCategoryId,
                                         recurrence.Name,
                                         householdId,
                                         recurrence.OriginId);

            var created = await _recurrenceRepository.AddAsync(toModel);

            await _recurrenceRepository.SaveChangesAsync();

            var createdDto = _mapper.Map<RecurrenceDto>(created);

            return CreatedAtAction(nameof(Get), createdDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var recurrence = await _recurrenceRepository.GetByIdAsync(id);

            if (recurrence == null)
                return NotFound();

            await _recurrenceRepository.DeleteAsync(recurrence);

            return NoContent();
        }

        [HttpPost("applications")]
        public async Task<IActionResult> PostApplications()
        {
            var recurrences = await _recurrenceRepository.ListAsync();

            foreach (var recurrence in recurrences)
            {
                if (recurrence.CanBeApplied())
                {
                    recurrence.Apply();
                    await _recurrenceRepository.UpdateAsync(recurrence);
                }
            }

            return Ok();
        }
    }
}
