﻿namespace Volunteer.BLModels.Entities
{
    using System;
    using Interfaces; 

    public class Rating : IRating
    {
        public Guid Uid { get; set; }
        public double Value { get; set; }
    }
}
