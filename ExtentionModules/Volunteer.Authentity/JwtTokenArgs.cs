namespace Volunteer.Authentity
{
    using System;
    using System.Collections.Generic;
    using System.Security.Claims;

    public class JwtTokenArgs
    {
        public JwtTokenArgs(string issuer, string audience, DateTime notBefore, IEnumerable<Claim> claims, DateTime? expires, string key)
        {
            this.Issuer = issuer;
            this.Audience = audience;
            this.NotBefore = notBefore;
            this.Claims = new List<Claim>(claims);
            this.Expires = expires;
            this.Key = key;
        }

        public string Issuer { get; private set; }
        public string Audience { get; private set; }
        public DateTime NotBefore { get; private set; }
        public IEnumerable<Claim> Claims { get; private set; }
        public DateTime? Expires { get; private set; }
        public string Key { get; private set; }
    }
}
