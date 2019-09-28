using System;
using System.Collections.Generic;

namespace Volunteer.RatingSystem.RatingDetails.Models
{
    public class ActivityRatingDetail
    {
        public Guid ActivityUid { get; set; }

        public double NumberOfViews { get; set; }

        public IEnumerable<TimeSpan> ViewingDuration { get; set; }

        public double SelfMarkRating { get; set; }
    }
}
