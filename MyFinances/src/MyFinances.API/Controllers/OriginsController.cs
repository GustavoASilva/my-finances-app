using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyFinances.Blazor.Shared.Origin;
using MyFinances.Core.Aggregates.Specifications;
using MyFinances.Core.Interfaces;
using MyFinances.Core.SyncedAggregates;

namespace MyFinances.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OriginsController : ControllerBase
    {
        private readonly IRepository<Origin> _originRepository;
        private IMapper _mapper;

        public OriginsController(IRepository<Origin> originRepository, IMapper mapper)
        {
            _originRepository = originRepository ?? throw new ArgumentNullException(nameof(originRepository));
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var spec = new OriginsNotDeletedSpec();
            List<Origin> origins = await _originRepository.ListAsync(spec);

            var dtos = _mapper.Map<List<OriginDto>>(origins);
            var response = new ListOriginsResponse(dtos);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateOriginRequest origin)
        {
            int householdId = 1;
            Origin? model = new Origin(origin.Alias, householdId);

            Origin? created = await _originRepository.AddAsync(model);

            await _originRepository.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), created);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            Origin? origin = await _originRepository.GetByIdAsync(id);

            if (origin == null)
                return NotFound();

            origin.SetDeletedAt(DateTime.Now);

            await _originRepository.SaveChangesAsync();

            return NoContent();
        }
    }
}
