namespace Volunteer.Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Finances.Services.CashFlowService;
    using Models;
    using Volunteer.Finances.Models;
    using Volunteer.Finances.Services.FundsService;

    [ApiController]
    public class CashFlowController : ControllerBase
    {
        private readonly ICashFlowService cashFlowService;
        private readonly IFundsService fundsService;

        public CashFlowController(ICashFlowService cashFlowService, IFundsService fundsService)
        {
            this.cashFlowService = cashFlowService;
            this.fundsService = fundsService;
        }

        [HttpGet("api/cashflows")]
        public IActionResult GetAll()
        {
            var cashFlows = this.cashFlowService.GetAll();

            if(cashFlows == null)
            {
                return NotFound(new { error = "Движения средств не найдены" });
            }

            return Ok(cashFlows);
        }

        [HttpGet("api/cashflows/{id}")]
        public IActionResult GetAll(Guid id)
        {
            var cashFlow = this.cashFlowService.FindByUid(id);

            if (cashFlow == null)
            {
                return NotFound(new { error = "Движения средств не найдены" });
            }

            return Ok(cashFlow);
        }

        [HttpPost("api/cashflows")]
        public IActionResult Create(CashFlowCreateModel model)
        {
            var fund = this.fundsService.GetFundById(model.FundUid);

            if(fund == null)
            {
                return StatusCode(404, new { error = "Фонд не найден" });
            }

            var cashFlow = new CashFlow
            {
                Amount = model.Amount,
                Fund = fund
            };

            if(this.cashFlowService.Save(cashFlow))
            {
                return Ok();
            }
            else
            {
                return StatusCode(500, new { error = "Ошибка при сохранении движения" });
            }
        }
    }
}