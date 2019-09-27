namespace VolunteerSystem
{
    using System;

    public class RatingLabel
    {
        IRating Rating { get; set; }
        EntityType EntityType { get; set; }
        Guid EntityUid { get; set; }
    }
}
