using System;
using Volunteer.BLModels.Entities;
using Volunteer.MainModule.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Volunteer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarksController : ControllerBase
    {
        private readonly IMarkService markService;

        public MarksController(IMarkService markService)
        {
            this.markService = markService;
        }

        // GET: api/Marks/55E9F0F5-396D-4BAB-BEEF-78ECD9EC963C
        [HttpGet("{stringEntityUid}", Name = "Get")]
        public ActionResult<Mark> Get(string stringEntityUid)
        {
            if (string.IsNullOrEmpty(stringEntityUid))
            {
                return BadRequest("Пустое значение идентификатора");
            }
            if (Guid.TryParse(stringEntityUid, out var entityUid))
            {
                return new JsonResult(markService.GetMarksByEntityUid(entityUid));
            }
            return BadRequest($"Идентификатор \"{stringEntityUid}\" имеет неверный формат. Используйте формат UUID");
        }

        // POST: api/Marks
        [HttpPost]
        public ActionResult Post([FromBody] Mark mark)
        {
            if (mark == null)
            {
                return BadRequest("Пустое значение оценки");
            }
            if (markService.SaveMark(mark))
            {
                return Ok();
            }
            return BadRequest("Ошибка сохранения");
        }
    }
}
