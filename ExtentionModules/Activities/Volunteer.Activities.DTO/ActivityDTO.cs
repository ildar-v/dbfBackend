﻿namespace Volunteer.Activities.DTO
{
    using System.Collections.Generic;
    using BLModels.Entities;
    using Comments.Entity;
    using Volunteer.Tags.Models;
    using Volunteer.Comments;
    using Volunteer.DTO;

    public class ActivityDTO
    {
        public Activity Activity { get; set; }
        public int Mark { get; set; }
        public IEnumerable<Tag> Tags { get; set; }
        public int CommentsCount { get; set; }
    }
}
