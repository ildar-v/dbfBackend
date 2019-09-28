namespace Volunteer.BLModels.Entities
{
    using System;
    using Enums;
    using Interfaces;

    public class ActivitiesUsers : IEntity
    {
        public Guid Uid { get; set; }
        public Guid UserGuid { get; set; }
        public Guid ActivityGuid { get; set; }
        public UserTypes UserType { get; set; }
    }
}
