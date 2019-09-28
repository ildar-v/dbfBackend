namespace Volunteer.Activities.DTO
{
    using System;
    using System.Collections.Generic;
    using BLModels.Interfaces;

    public class ActivityCreateDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        //public ILocation Location { get; set; }
        public string ImageUrl { get; set; }
        public ICollection<Guid> AuthorUids { get; set; }
    }
}
