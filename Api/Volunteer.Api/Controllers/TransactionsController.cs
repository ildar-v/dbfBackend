using Microsoft.AspNetCore.Mvc;
using System;
using Volunteer.Finances.Services.TransactionService;

namespace Volunteer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionService transactionService;

        public TransactionsController(ITransactionService transactionService)
        {
            this.transactionService = transactionService;
        }

        // POST: api/Transactions
        [HttpPost]
        public ActionResult Post([FromBody] string stringFundUid, decimal amount)
        {
            if (string.IsNullOrWhiteSpace(stringFundUid))
            {
                return BadRequest("Пустое значение идентификатора");
            }

            if (Guid.TryParse(stringFundUid, out var fundUid))
            {
                if (transactionService.Deposit(amount, fundUid))
                {
                    return Ok();
                }
                return BadRequest("Ошибка сохранения");
            }
            return BadRequest($"Идентификатор \"{stringFundUid}\" имеет неверный формат. Используйте формат UUID");
        }
    }
}
