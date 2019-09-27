namespace VolunteerSystem
{
    using System;
    using System.Collections.Generic;
    
    public class Activity : IBusinessModel
    {
        public Guid Uid { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ILocation Location { get; set; }
        public ICollection<Report> Reports { get; set; }
    }
}
