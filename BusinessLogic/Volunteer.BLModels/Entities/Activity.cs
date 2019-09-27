namespace Volunteer.BLModels.Entities
{
    using System;
    using Interfaces;

    public class Activity : IEntity, IRatingable
    {
        public Guid Uid { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ILocation Location { get; set; }
        public IReport Report { get; set; }
        public IRating Rating { get; set; }
        public DateTime AddDateTime { get; set; }
    }
}
