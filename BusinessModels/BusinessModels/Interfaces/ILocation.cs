namespace Volunteer.BusinessModels.Interfaces
{
    using System;
    using System.Collections.Generic;

    public interface ILocation : IBusinessModel
    {
        ICollection<Guid> ActivitiesUids { get; set; }
        ICollection<Guid> UserUids { get; set; }
    }
}
