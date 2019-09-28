namespace Volunteer.Api.ViewModels.Comment
{
    using System;

    public class CommentViewModel
    {
        public string Text { get; set; }
        public Guid AuthorUid { get; set; }
        public Guid EntityUid { get; set; }
        public RatingViewModel Rating { get; set; }
        public CommentViewModel Parent { get; set; }
        public DateTime AddDateTime { get; set; }
    }
}
