namespace Volunteer.Api.Controllers
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using Api.ViewModels;
    using MainModule.Services.Interfaces;
    using MainModule.Managers.Filters;

    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet("api/users")]
        public ActionResult<IEnumerable<UserListViewModel>> GetAll()
        {
            var data = userService.Find();
            return Ok(data);
        }

        [HttpGet("api/user/{searchStr}")]
        public ActionResult<IEnumerable<UserListViewModel>> GetAll(string searchStr)
        {
            var data = this.userService.FindScalarByUidOrLogin(searchStr);
            return Ok(data);
        }
    }
}
