namespace Volunteer.Api.Controllers
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using Api.ViewModels;
    using MainModule.Services.Interfaces;
    using MainModule.Managers.Filters;
    using AutoMapper;
    using Authentity;
    using Microsoft.AspNetCore.Authorization;
    using Authentity.Model;
    using System.IdentityModel.Tokens.Jwt;
    using Microsoft.IdentityModel.Tokens;
    using System.Text;

    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly Authentification authentification;
        private readonly IMapper mapper;

        public AccountController(Authentification authentification)
        {
            this.authentification = authentification;
        }

        [AllowAnonymous, HttpPost("/login")]
        public IActionResult Login([FromBody]PasswordLoginModel model)
        {
            var tokenArgs = this.authentification.PasswordLogin(model);

            if (tokenArgs == null)
            {
                return StatusCode(403, "Введен неверный логин или пароль");
            }

            JwtSecurityToken token = this.GetJwtToken(tokenArgs);
            var encodedToken = new JwtSecurityTokenHandler().WriteToken(token);
            return Ok(new { uid = tokenArgs.UserUid, access_token = encodedToken });
        }

        [AllowAnonymous, HttpPost("/registration")]
        public IActionResult Registration([FromBody] RegisterModel model)
        {
            var tokenArgs = this.authentification.Registration(model);

            if (tokenArgs == null)
            {
                return StatusCode(500, "Произошла ошибка при регистрации");
            }

            JwtSecurityToken token = this.GetJwtToken(tokenArgs);
            var encodedToken = new JwtSecurityTokenHandler().WriteToken(token);
            return Ok(new { uid = tokenArgs.UserUid, access_token = encodedToken });
        }

        private JwtSecurityToken GetJwtToken(JwtTokenArgs args)
        {
            return new JwtSecurityToken(
                issuer: args.Issuer,
                audience: args.Audience,
                notBefore: args.NotBefore,
                claims: args.Claims,
                expires: args.Expires,
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(args.Key)), SecurityAlgorithms.HmacSha256));
        }
    }
}
