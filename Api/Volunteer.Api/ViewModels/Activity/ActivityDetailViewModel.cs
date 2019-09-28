﻿namespace Volunteer.Api.ViewModels.Activity
{
    using System;
    using System.Collections.Generic;
    using Api.ViewModels.Comment;

    public class ActivityDetailViewModel
    {
        public Guid Uid { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public RatingViewModel Rating { get; set; }
        public DateTime AddDateTime { get; set; }
        public IEnumerable<CommentViewModel> Comments { get; set; }
    }
}