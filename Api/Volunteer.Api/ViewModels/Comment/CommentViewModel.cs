namespace Volunteer.Api.ViewModels.Comment
{
    using System;

    public class CommentViewModel
    {
        public Guid Uid { get; set; }
        public string Text { get; set; }
        public Guid AuthorUid { get; set; }
        public UserViewModel Author { get; set; }
        public Guid EntityUid { get; set; }
        public DateTime AddDateTime { get; set; }
        public int Mark { get; set; }
    }
}
