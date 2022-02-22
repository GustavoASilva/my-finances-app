using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyFinances.API.Dtos;
using MyFinances.Blazor.Shared.Transactions;
using MyFinances.Core.Interfaces;
using MyFinances.Core.TransactionAggregate;

namespace MyFinances.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly IRepository<Transaction> _transactionRepository;
        private IMapper _mapper;

        public TransactionsController(IRepository<Transaction> transactionRepository, IMapper mapper)
        {
            _transactionRepository = transactionRepository ?? throw new ArgumentNullException(nameof(transactionRepository));
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetTransactionsInRangeRequest request)
        {
            //var spec = new TransactionsByHouseholdIdAndDateRangeSpec(1, request.DateTimeRange);
            
            var transactions = await _transactionRepository.ListAsync();

            _mapper.Map<List<GetTransactionsInRangeResponse>>(transactions);
            return Ok(transactions);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateTransactionRequest transaction)
        {
            var toModel = _mapper.Map<Transaction>(transaction);
            toModel.SetHouseholdId(1);

            var created = await _transactionRepository.AddAsync(toModel);

            await _transactionRepository.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), created);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] UpdateTransactionRequest transaction)
        {
            var toModel = _mapper.Map<Transaction>(transaction);
            toModel.SetHouseholdId(1);
            toModel.Id = id;

            await _transactionRepository.UpdateAsync(toModel);

            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch([FromRoute] Guid id, [FromBody] PatchTransactionRequest patch)
        {
            var transaction = await _transactionRepository.GetByIdAsync(id);

            if (transaction == null)
                return NotFound();

            transaction.SetConfirmedDate(patch.ConfirmedDate);

            await _transactionRepository.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var transaction = await _transactionRepository.GetByIdAsync(id);

            if (transaction == null)
                return NotFound();

            await _transactionRepository.DeleteAsync(transaction);

            return NoContent();
        }
    }
}
