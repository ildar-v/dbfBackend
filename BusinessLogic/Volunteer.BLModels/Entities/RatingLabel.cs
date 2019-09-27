namespace Volunteer.BLModels.Entities
{
    using System;
    using Interfaces;

    public class RatingLabel
    {
        public IRating Rating { get; set; }
        public Type EntityType { get; set; }
        public Guid EntityUid { get; set; }
    }
}
