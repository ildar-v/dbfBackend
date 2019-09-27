namespace Volunteer.BLModels.Entities
{
    using System;
    using Interfaces; 

    public class Rating : IRating
    {
        public double Value { get; set; }
        public Guid Uid { get; set; }
    }
}
