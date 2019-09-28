namespace Volunteer.Api.Controllers
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using Api.ViewModels;
    using MainModule.Services.Interfaces;
    using MainModule.Managers.Filters;
    using AutoMapper;

    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
        }

        [HttpGet("api/users")]
        public ActionResult<IEnumerable<UserViewModel>> GetAll()
        {
            var userDTOs = userService.Find();

            if (userDTOs != null)
            {
                var users = this.mapper.Map<IEnumerable<UserViewModel>>(userDTOs);
                return Ok(users);
            }

            return NotFound();
        }

        [HttpGet("api/user/{uidOrLogin}")]
        public ActionResult<UserViewModel> Get(string uidOrLogin)
        {
            var userDTO = this.userService.FindScalarByUidOrLogin(uidOrLogin);

            if (userDTO != null)
            {
                var user = this.mapper.Map<UserViewModel>(userDTO);
                return Ok(user);
            }

            return NotFound();
        }
    }
}
