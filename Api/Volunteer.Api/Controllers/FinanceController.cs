namespace Volunteer.Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Get()
        {
            var funds = this.fundsInteractor.GetAllFunds();

            if(funds == null)
            {
                return NotFound(new { error = "Фонды не найдены" });
            }

            var result = this.mapper.Map<IEnumerable<FundViewModel>>(funds);
            return Ok(result);
        }

        [HttpGet("api/{id}")]
        public IActionResult Get(Guid id)
        {
            var fund = this.fundsInteractor.FindByUid(id);

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
            this.fundsInteractor.NewFund(model.Title, model.Description, model.Budget, model.StartDate, model.EndDate);
            return Ok(new { success = "Фонд создан" });
        }
    }
}
