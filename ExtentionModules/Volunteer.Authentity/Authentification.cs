namespace Volunteer.Authentity
{
    using System;
    using Authentity.Model;
    using MainModule.Services.Interfaces;
    using DTO;
    using System.Collections.Generic;
    using System.Security.Claims;

    public class Authentification
    {
        private readonly IUserService userService;

        public Authentification(IUserService userService)
        {
            this.userService = userService;
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
