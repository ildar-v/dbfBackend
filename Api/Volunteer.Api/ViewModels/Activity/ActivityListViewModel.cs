namespace Volunteer.Api.ViewModels.Activity
{
    using System;

    public class ActivityListViewModel
    {
        public Guid Uid { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public RatingViewModel Rating { get; set; }
        public DateTime AddDateTime { get; set; }
        public int CommentCount { get; set; }
    }
}
