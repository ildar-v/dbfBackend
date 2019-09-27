namespace Volunteer.BLModels.Interfaces
{
    using System;
    using System.Collections.Generic;

    public interface ILocation : IEntity
    {
        ICollection<Guid> ActivitiesUids { get; set; }
        ICollection<Guid> UserUids { get; set; }
    }
}
