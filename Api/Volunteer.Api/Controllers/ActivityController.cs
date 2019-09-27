using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Volunteer.Activities.Interactor;
using Volunteer.Activities.DTO;

namespace Volunteer.Api.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly ActivitiesInteractor activitiesInteractor;

        public ActivityController(ActivitiesInteractor activitiesInteractor)
        {
            this.activitiesInteractor = activitiesInteractor;
        }

        // GET api/values
        [HttpGet("api/activities")]
        public ActionResult<IEnumerable<ActivityDTO>> Get()
        {
            var data = activitiesInteractor.Find();
            return Ok(data);
        }

        //// GET api/values/5
        //[HttpGet("{id}")]
        //public ActionResult<string> Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/values
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
