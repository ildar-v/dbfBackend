namespace Volunteer.Api.Controllers
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using Api.ViewModels;
    using MainModule.Services.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using AutoMapper;
    using Volunteer.BLModels.Entities;
    using System;
    using Volunteer.MainModule.Managers;
    using Volunteer.Api.ViewModels.User;

    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;
        private readonly ISimpleManager<ActivitiesUsers> activitiesUsersService;

        public UserController(IUserService userService, IMapper mapper, ISimpleManager<ActivitiesUsers> activitiesUsersService)
        {
            this.userService = userService;
            this.mapper = mapper;
            this.activitiesUsersService = activitiesUsersService;
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

        [HttpPost("api/user")]
        public ActionResult Post([FromBody]UserActivityModel model)
        {
            var entry = new ActivitiesUsers
            {
                ActivityGuid = model.ActivityUid,
                UserGuid = model.UserUid,
                Uid = Guid.NewGuid(),
                UserType = BLModels.Enums.UserTypes.Volunteer
            };
            if (activitiesUsersService.Save(entry))
            {
                return Ok();
            }
            return BadRequest("Ошибка сохранения");
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
