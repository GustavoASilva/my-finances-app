using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFinances.Core.Aggregates;
using MyFinances.Core.Aggregates.Specifications;
using MyFinances.Core.Interfaces;

namespace MyFinances.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly IRepository<Transaction> repository;

        public TransactionController(IRepository<Transaction> repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int houseHoldId)
        {
            var spec = new TransactionsByHouseholdIdSpec(houseHoldId);
            var results = await repository.ListAsync(spec);
            return Ok(results);
        }
    }
}
