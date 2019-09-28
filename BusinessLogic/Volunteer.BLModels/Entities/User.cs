namespace Volunteer.BLModels.Entities
{
    using System;
    using System.Collections.Generic;
    using Interfaces;

    public class User : IEntity, IEvaluated
    {
        public Guid Uid { get; set; }
        public string FullName { get; set; }
        public string Login { get; set; }
        public string PasswordHash { get; set; }
        public string AvatarUrl { get; set; }
        public string About { get; set; }
        public IEnumerable<Mark> Marks { get; set; }
    }
}
