namespace Volunteer.BLModels.Entities
{
    using System;
    using System.Collections.Generic;
    using Interfaces;

    public class Activity : IEntity, IEvaluated
    {
        public Guid Uid { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ILocation Location { get; set; }
        public IReport Report { get; set; }
        public DateTime AddDateTime { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string ImageUrl { get; set; }
        public IEnumerable<Mark> Marks { get; set; }
    }
}
