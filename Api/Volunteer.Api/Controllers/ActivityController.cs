namespace Volunteer.Api.Controllers
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using Volunteer.Activities.Interactor;
    using Volunteer.Activities.DTO;

    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly ActivitiesInteractor activitiesInteractor;

        public ActivityController(ActivitiesInteractor activitiesInteractor)
        {
            this.activitiesInteractor = activitiesInteractor;
        }

        [HttpGet("api/activities")]
        public ActionResult<IEnumerable<ActivityDTO>> Get()
        {
            var data = activitiesInteractor.Find();
            return Ok(data);
        }
    }
}
