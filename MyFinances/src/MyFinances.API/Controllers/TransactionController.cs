using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyFinances.API.Dtos;
using MyFinances.Blazor.Shared;
using MyFinances.Core.Interfaces;
using MyFinances.Core.SyncedAggregates;
using MyFinances.Core.SyncedAggregates.Specifications;

namespace MyFinances.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly IRepository<Transaction> _transactionRepository;
        private IMapper _mapper;

        public TransactionController(IRepository<Transaction> transactionRepository, IMapper mapper)
        {
            _transactionRepository = transactionRepository ?? throw new ArgumentNullException(nameof(transactionRepository));
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetTransactionsInRangeRequest request)
        {
            var spec = new TransactionsByHouseholdIdAndDateRangeSpec(1, request.DateTimeRange);
            
            var transactions = await _transactionRepository.ListAsync(spec);

            _mapper.Map<List<GetTransactionsInRangeResponse>>(transactions);
            return Ok(transactions);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddNewTransactionRequest transaction)
        {
            var toModel = _mapper.Map<Transaction>(transaction);
            transaction.HouseholdId = 1;
            var created = await _transactionRepository.AddAsync(toModel);

            await _transactionRepository.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), created);
        }
    }
}
