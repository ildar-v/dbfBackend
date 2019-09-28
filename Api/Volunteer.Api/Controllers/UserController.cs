namespace Volunteer.Api.Controllers
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using Api.ViewModels;
    using MainModule.Services.Interfaces;
    using Microsoft.AspNetCore.Authorization;
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
        public ActionResult<IEnumerable<UserListViewModel>> GetAll()
        {
            var data = userService.Find();
            
            if(data != null)
            {
                var viewModel = this.mapper.Map<IEnumerable<UserListViewModel>>(data);
                return Ok(viewModel);
            }

            return NotFound();
        }

        [HttpGet("api/user/{searchStr}")]
        public ActionResult<IEnumerable<UserListViewModel>> Get(string searchStr)
        {
            var data = this.userService.FindScalarByUidOrLogin(searchStr);

            if (data != null)
            {
                var viewModel = this.mapper.Map<UserListViewModel>(data);
                return Ok(viewModel);
            }

            return Ok(data);
        }
    }
}
