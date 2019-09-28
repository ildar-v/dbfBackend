namespace Volunteer.Api.Models
{
    using System;
    using System.Collections.Generic;

    public class ActivityCreateModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        //public ILocationDTO Location { get; set; }
        public string ImageUrl { get; set; }
        public IEnumerable<Guid> AuthorUids { get; set; }
    }
}
