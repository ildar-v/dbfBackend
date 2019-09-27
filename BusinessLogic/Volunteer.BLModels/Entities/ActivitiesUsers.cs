namespace Volunteer.BLModels.Entities
{
    using System;
    using Enums;
    using Interfaces;

    public class ActivitiesUsers : IEntity
    {
        public Guid Uid { get; set; }
        public User User { get; set; }
        public Activity Activity { get; set; }
        public UserTypes UserType { get; set; }
    }
}
