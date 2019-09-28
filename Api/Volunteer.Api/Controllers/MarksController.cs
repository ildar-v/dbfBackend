using System;
using Volunteer.BLModels.Entities;
using Volunteer.MainModule.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Volunteer.Api.Models;

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
        [HttpGet(Name = "Get")]
        public ActionResult<Mark> Get([FromQuery] MarkModel model)
        {
            if (string.IsNullOrEmpty(model.UserUid) && string.IsNullOrEmpty(model.EntityUid))
            {
                return BadRequest("Пустое значение идентификатора");
            }
            if (!Guid.TryParse(model.UserUid, out var userUidGuid))
            {
                return BadRequest($"Идентификатор \"{model.UserUid}\" имеет неверный формат. Используйте формат UUID");
            }
            if (!Guid.TryParse(model.EntityUid, out var entityUidGuid))
            {
                return BadRequest($"Идентификатор \"{model.EntityUid}\" имеет неверный формат. Используйте формат UUID");
            }

            return new JsonResult(markService.GetMark(userUidGuid, entityUidGuid));
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
