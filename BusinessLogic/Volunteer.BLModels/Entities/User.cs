namespace Volunteer.BLModels.Entities
{
    using System;
    using System.Collections.Generic;
    using Interfaces;

    public class User : IEntity, IRatingable
    {
        public Guid Uid { get; set; }
        public string FullName { get; set; }
        public string Login { get; set; }
        public string PasswordHash { get; set; }
        public ICollection<ActivitiesUsers> ActivitiesUsers { get; set; }
        public IRating Rating { get; set; }
    }
}
