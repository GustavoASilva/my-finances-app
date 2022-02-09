using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyFinances.API.Dtos;
using MyFinances.Blazor.Shared.Origins;
using MyFinances.Blazor.Shared.Transactions;
using MyFinances.Core.Interfaces;
using MyFinances.Core.SyncedAggregates;
using MyFinances.Core.SyncedAggregates.Specifications;

namespace MyFinances.API.Controllers
{
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
            var origins = await _originRepository.ListAsync();
            var mapped = _mapper.Map<List<GetOriginsResponse>>(origins);

            return Ok(mapped);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateOriginRequest origin)
        {
            var toModel = _mapper.Map<Origin>(origin);
            toModel.SetHouseholdId(1);

            var created = await _originRepository.AddAsync(toModel);

            await _originRepository.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), created);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var origin = await _originRepository.GetByIdAsync(id);

            if (origin == null)
                return NotFound();

            await _originRepository.DeleteAsync(origin);

            return NoContent();
        }
    }
}
