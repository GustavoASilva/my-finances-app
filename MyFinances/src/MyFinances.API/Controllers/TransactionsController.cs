using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyFinances.Blazor.Shared.Transaction;
using MyFinances.Core.Interfaces;
using MyFinances.Core.SyncedAggregates;
using MyFinances.Core.TransactionAggregate;
using MyFinances.Core.TransactionAggregate.Specification;

namespace MyFinances.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly IRepository<Transaction> _transactionRepository;
        private readonly IRepository<Origin> _originRepository;
        private IMapper _mapper;

        public TransactionsController(IRepository<Transaction> transactionRepository, IMapper mapper, IRepository<Origin> originRepository)
        {
            _transactionRepository = transactionRepository ?? throw new ArgumentNullException(nameof(transactionRepository));
            _originRepository = originRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get(DateTime? estimatedDateStart, DateTime? estimatedDateEnd)
        {
            var spec = new TransactionFilterSpec(estimatedDateStart, estimatedDateEnd);

            var transactions = await _transactionRepository.ListAsync(spec);
            var transactionsDto = _mapper.Map<List<TransactionDto>>(transactions);

            var origins = await _originRepository.ListAsync();
            foreach (var transaction in transactionsDto)
            {
                transaction.OriginName = origins.Single(o => o.Id == transaction.OriginId).Alias;
            }

            var response = new ListTransactionsResponse(transactionsDto);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateTransactionRequest transaction)
        {
            var householdId = 1;
            var toModel = new Transaction(transaction.Value, transaction.CategoryId, householdId, transaction.OriginId, transaction.Description, transaction.EstimatedDate);

            var created = await _transactionRepository.AddAsync(toModel);

            await _transactionRepository.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), created);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] UpdateTransactionRequest updateTransaction)
        {
            Transaction? transaction = await _transactionRepository.GetByIdAsync(id);

            if (transaction == null)
                return NotFound();

            transaction.UpdateEstimatedDate(updateTransaction.EstimatedDate);
            transaction.UpdateDescription(updateTransaction.Description);
            transaction.UpdateValue(updateTransaction.Value);
            transaction.SetConfirmed(updateTransaction.Confirmed);


            await _transactionRepository.UpdateAsync(transaction);

            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch([FromRoute] Guid id, [FromBody] PatchTransactionRequest patch)
        {
            var transaction = await _transactionRepository.GetByIdAsync(id);

            if (transaction == null)
                return NotFound();

            transaction.SetConfirmed(patch.Confirmed);

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
