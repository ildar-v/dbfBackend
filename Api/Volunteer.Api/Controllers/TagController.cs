using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TempDAL;
using Volunteer.Api.ViewModels;
using Volunteer.MainModule.Managers;
using Volunteer.MainModule.Managers.Filters;
using Volunteer.Tags.Models;

namespace Volunteer.Api.Controllers
{
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ISimpleManager<Tag> tagSimpleManager;

        public TagController(IMapper mapper, ISimpleManager<Tag> tagSimpleManager)
        {
            this.mapper = mapper;
            this.tagSimpleManager = tagSimpleManager;
        }

        [HttpGet("api/tag")]
        public ActionResult<IEnumerable<TagViewModel>> Get()
        {
            var tags = tagSimpleManager.Find();
            var tagVMs = mapper.Map<IEnumerable<TagViewModel>>(tags);
            return Ok(tagVMs);
        }

        [HttpPost("api/tag")]
        public ActionResult<IEnumerable<TagViewModel>> Post(TagModel tagModel)
        {
            var tag = new Tag
            {
                Name = tagModel.Name,
                EntityUids = new List<Guid> { tagModel.EntityUid }
            };
            tagSimpleManager.Save(tag);
            var tags = tagSimpleManager.Find().Where(x => x.EntityUids.Contains(tagModel.EntityUid));
            var tagVMs = mapper.Map<IEnumerable<TagViewModel>>(tags);
            return Ok(tagVMs);
        }

        [HttpDelete("api/tag")]
        public ActionResult Delete(TagModel tagModel)
        {
            var tag = TagsDataManager.tempStore.Single(x => x.Name == tagModel.Name);
            tag.EntityUids.Remove(tagModel.EntityUid);
            return Ok();
        }
    }
}