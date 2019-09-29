namespace Volunteer.Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using Volunteer.Api.Models;
    using Volunteer.Api.ViewModels.Finance;
    using Volunteer.Finances;
    using Volunteer.Finances.Models;
    using Volunteer.Finances.Services.FundsService;

    [ApiController]
    public class FinanceController : ControllerBase
    {
        private readonly FundsInteractor fundsInteractor;
        private readonly IMapper mapper;

        public FinanceController(FundsInteractor fundsInteractor, IMapper mapper)
        {
            this.fundsInteractor = fundsInteractor;
            this.mapper = mapper;
        }

        [HttpGet("api/fund")]
        public IActionResult GetAllFunds()
        {
            var funds = this.fundsInteractor.GetAllFunds();

            if(funds == null)
            {
                return NotFound(new { error = "Фонды не найдены" });
            }

            var result = this.mapper.Map<IEnumerable<FundViewModel>>(funds);
            return Ok(result);
        }

        [HttpGet("api/fund/{id}")]
        public IActionResult GetFund(Guid id)

        {
            var fund = this.fundsInteractor.FindFundByUid(id);

            if(fund == null)
            {
                return NotFound(new { error = "Фонды не найдены" });
            }

            var result = this.mapper.Map<FundDetailViewModel>(fund);
            return Ok(result);
        }

        [HttpPost("api/fund")]
        public IActionResult CreateFund([FromBody] FundCreateModel model)
        {
            this.fundsInteractor.NewFund(model.Title, model.Description, model.StartDate, model.EndDate);
            return Ok(new { success = "Фонд создан" });
        }

        [HttpGet("api/cashflows")]
        public IActionResult GetAllCashFlows()
        {
            var cashFlows = this.fundsInteractor.GetAllCashFlows();

            if (cashFlows == null)
            {
                return NotFound(new { error = "Движения средств не найдены" });
            }

            var result = this.mapper.Map<IEnumerable<CashFlowViewModel>>(cashFlows);
            return Ok(result);
        }


        [HttpGet("api/cashflows/{id}")]
        public IActionResult GetCashFlow(Guid id)
        {
            var cashFlow = this.fundsInteractor.FindCashFlowByUid(id);

            if (cashFlow == null)
            {
                return NotFound(new { error = "Движения средств не найдены" });
            }

            var result = this.mapper.Map<CashFlowViewModel>(cashFlow);
            return Ok(result);
        }

        [HttpPost("api/cashflows")]
        public IActionResult Create(CashFlowCreateModel model)
        {
            var fund = this.fundsInteractor.FindFundByUid(model.FundUid);

            if (fund == null)
            {
                return NotFound(new { error = "Фонд не найден" });
            }

            this.fundsInteractor.NewCashFlow(model.Amount, model.FundUid, model.ActivityUid);

            return Ok(new { success = "Движение средств успешно записано" });
        }
    }
}
