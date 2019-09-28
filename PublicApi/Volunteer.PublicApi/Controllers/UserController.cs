
namespace Volunteer.PublicApi.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using PublicApi.VIewModels;
    using MainModule.Services.Interfaces;
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

        [HttpGet("api/users/{id}")]
        public IActionResult Get(string searchStr)
        {
            var user = this.userService.FindScalarByUidOrLogin(searchStr);

            if(user == null)
            {
                return StatusCode(404, new { error = "Пользователь не найден" });
            }

            var result = this.mapper.Map<UserViewModel>(user);
            return Ok(result);
        }

        [HttpGet("api/users")]
        public IActionResult Get()
        {
            var users = this.userService.Find();

            if (users == null)
            {
                return StatusCode(404, new { error = "Пользователи не найдены" });
            }

            var result = this.mapper.Map<IEnumerable<UserViewModel>>(users);
            return Ok(result);
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
