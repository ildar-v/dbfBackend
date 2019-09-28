using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volunteer.Finances.Models;
using Volunteer.Finances.Services.FundsService;

namespace Volunteer.Api.Controllers
{
    [ApiController]
    public class FundController : ControllerBase
    {
        private readonly IFundsService fundsService;

        public FundController(IFundsService fundsService)
        {
            this.fundsService = fundsService;
        }

        // GET: api/Fund
        [HttpGet("api/fund")]
        public ActionResult<IEnumerable<Fund>> Get()
        {
            return new JsonResult(fundsService.GetAllFunds());
        }

        // GET: api/Fund/55E9F0F5-396D-4BAB-BEEF-78ECD9EC963C
        [HttpGet("api/{stringFundUid}")]
        public ActionResult<Fund> Get(string stringFundUid)
        {
            if (string.IsNullOrEmpty(stringFundUid))
            {
                return BadRequest("Пустое значение идентификатора");
            }
            if (Guid.TryParse(stringFundUid, out var uid))
            {
                return new JsonResult(fundsService.GetFundById(uid));
            }
            return BadRequest($"Идентификатор \"{stringFundUid}\" имеет неверный формат. Используйте формат UUID");
        }

        // POST: api/Fund
        [HttpPost("api/fund")]
        public ActionResult Post([FromBody] Fund fund)
        {
            if (fund == null)
            {
                return BadRequest("Пустое значение оценки");
            }
            if (fundsService.Save(fund))
            {
                return Ok();
            }
            return BadRequest("Ошибка сохранения");
        }
    }
}
