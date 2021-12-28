using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFinances.API.Dtos;
using MyFinances.Core.Aggregates.HouseholdAggregate;
using MyFinances.Core.Aggregates.HouseholdAggregate.Specifications;
using MyFinances.Core.Interfaces;

namespace MyFinances.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly IRepository<Household> _householdRepository;
        private IMapper _mapper;

        public TransactionController(IRepository<Household> householdRepository, IMapper mapper)
        {
            _householdRepository = householdRepository ?? throw new ArgumentNullException(nameof(householdRepository));
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int householdId)
        {
            var spec = new HouseholdByIdWithTransactionsSpec(householdId);
            var household = await _householdRepository.GetBySpecAsync(spec);
            
            if (household == null) return NotFound();

            return Ok(household?.Transactions);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddNewTransactionRequest transaction)
        {
            var household = await _householdRepository.GetByIdAsync(transaction.HouseholdId);
            if (household == null) return BadRequest();

            var toModel = _mapper.Map<Transaction>(transaction);

            var created = household.AddNewTransaction(toModel);

            return CreatedAtAction(nameof(Get), created);
        }
    }
}
