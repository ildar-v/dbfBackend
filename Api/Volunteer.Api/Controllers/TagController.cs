using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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

        [HttpPost]
        public IActionResult Post(TagModel tagModel)
        {
            var tag = mapper.Map<Tag>(tagModel);
            tagSimpleManager.Save(tag);
            var tags = tagSimpleManager.Find(new Filter(nameof(Tag.Name), new object[] { tagModel.Name }));
            var tagVMs = mapper.Map<TagViewModel>(tags);
            return Ok(tagVMs);
        }
    }
}