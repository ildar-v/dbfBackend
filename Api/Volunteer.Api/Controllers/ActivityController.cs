namespace Volunteer.Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using AutoMapper;
    using Activities.Interactor;
    using Activities.DTO;
    using Api.ViewModels.Activity;
    using Api.Models;
    using MainModule.Services.Interfaces;

    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly ActivitiesInteractor activitiesInteractor;
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public ActivityController(ActivitiesInteractor activitiesInteractor, IUserService userService, IMapper mapper)
        {
            this.activitiesInteractor = activitiesInteractor;
            this.mapper = mapper;
            this.userService = userService;
        }

        [HttpGet("api/activities")]
        public ActionResult<IEnumerable<ActivityViewModel>> Get()
        {
            var data = this.activitiesInteractor.Find();

            if (data != null)
            {
                var result = mapper.Map<IEnumerable<ActivityViewModel>>(data);
                return Ok(result);
            }

            return new NotFoundResult();
        }

        [HttpGet("api/activity/{id}")]
        public ActionResult<ActivityDetailViewModel> Get(Guid id)
        {
            var dto = this.activitiesInteractor.FindScalarByUid(id);

            if (dto != null)
            {
                var result = mapper.Map<ActivityDetailViewModel>(dto);
                return Ok(result);
            }

            return new NotFoundResult();
        }

        [HttpPost("api/activity")]
        public ActionResult<ActivityDetailViewModel> Post([FromBody]ActivityCreateModel activityModel)
        {
            var newActivity = mapper.Map<ActivityCreateDTO>(activityModel);
            var currentUser = this.userService.FindByLogin("Max");//this.userService.FindByLogin(User.Identity.Name);

            if (currentUser != null)
            {
                if(newActivity.AuthorUids == null)
                {
                    newActivity.AuthorUids = new List<Guid>();
                }

                newActivity.AuthorUids.Add(currentUser.Uid);

                if(this.activitiesInteractor.Save(newActivity))
                {
                    return Ok(new { success = "Мероприятие создано" });
                }
            }

            return StatusCode(403);
        }

        //[HttpPut("api/activity")]
        //public ActionResult<ActivityDetailViewModel> Put([FromBody]ActivityUpdateModel activityModel)
        //{
        //    var newActivity = mapper.Map<ActivityUpdateDTO>(activityModel);
        //    this.activitiesInteractor.Save(newActivity);
        //    return Ok();
        //}
    }
}
