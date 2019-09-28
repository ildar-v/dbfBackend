namespace Volunteer.Authentity
{
    using System;
    using Authentity.Model;
    using MainModule.Services.Interfaces;
    using DTO;
    using System.Collections.Generic;
    using System.Security.Claims;
    using AutoMapper;

    public class Authentification
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public Authentification(IUserService userService, IMapper mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
        }

        public JwtTokenArgs PasswordLogin(PasswordLoginModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            UserDTO user = this.userService.FindByLogin(model.Login);

            if (user == null || user.PasswordHash != model.Password)
                return null;

            DateTime now = DateTime.UtcNow;

            return new JwtTokenArgs(AuthOptions.Issuer,
                                    AuthOptions.Audience,
                                    now,
                                    this.GetUserClaims(user),
                                    now.Add(TimeSpan.FromMinutes(AuthOptions.LifeTimeInMinutes)),
                                    AuthOptions.Key,
                                    user.Uid);
        }

        public JwtTokenArgs Registration(RegisterModel model)
        {
            var user = this.userService.FindByLogin(model.Login);

            if (user != null)
                return null;

            if (model.Password != model.RepeatPassword)
                return null;

            user = this.mapper.Map<UserDTO>(model);

            if(this.userService.CreateOrUpdate(user))
            {
                user = this.userService.FindByLogin(model.Login);
                IEnumerable<Claim> claims = this.GetUserClaims(user);
                DateTime now = DateTime.UtcNow;
                return new JwtTokenArgs(AuthOptions.Issuer,
                                        AuthOptions.Audience,
                                        now,
                                        this.GetUserClaims(user),
                                        now.Add(TimeSpan.FromMinutes(AuthOptions.LifeTimeInMinutes)),
                                        AuthOptions.Key, user.Uid );
            }
            else
            {
                return null;
            }

        }

        private IEnumerable<Claim> GetUserClaims(UserDTO user)
        {
            if (user == null)
            {
                return null;
            }

            List<Claim> claims = new List<Claim>
            {
                new Claim("Login", user.Login),
                new Claim("Id", user.Uid.ToString())
            };

            return claims;
        }
    }
}
