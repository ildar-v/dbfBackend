namespace Volunteer.Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using AutoMapper;
    using Activities.Interactor;
    using Activities.DTO;
    using Api.ViewModels.Activity;

    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly ActivitiesInteractor activitiesInteractor;
        private readonly IMapper mapper;

        public ActivityController(ActivitiesInteractor activitiesInteractor, IMapper mapper)
        {
            this.activitiesInteractor = activitiesInteractor;
            this.mapper = mapper;
        }

        [HttpGet("api/activities")]
        public ActionResult<IEnumerable<ActivityDTO>> Get()
        {
            IEnumerable<ActivityDTO> data = this.activitiesInteractor.Find();

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
    }
}
