namespace Volunteer.Api.ViewModels.Activity
{
    using System;
    using System.Collections.Generic;
    using Volunteer.Tags.Models;

    public class ActivityViewModel
    {
        public Guid Uid { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime AddDateTime { get; set; }
        public IEnumerable<TagViewModel> Tags { get; set; }
        public int Mark { get; set; }
        public int CommentsCount { get; set; }
    }
}
