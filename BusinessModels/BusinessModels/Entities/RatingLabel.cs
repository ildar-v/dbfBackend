namespace VolunteerSystem.Entities
{
    using System;
    using Interfaces;

    public class RatingLabel
    {
        IRating Rating { get; set; }
        Type EntityType { get; set; }
        Guid EntityUid { get; set; }
    }
}
