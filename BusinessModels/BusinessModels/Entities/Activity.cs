namespace VolunteerSystem.Entities
{
    using System;
    using Interfaces;

    public class Activity : IBusinessModel, IRatingable
    {
        public Guid Uid { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ILocation Location { get; set; }
        public IReport Report { get; set; }
        public IRating Rating { get; set; }
    }
}
