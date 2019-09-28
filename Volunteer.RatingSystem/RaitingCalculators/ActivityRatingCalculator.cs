using System;
using System.Linq;
using Volunteer.BLModels.Entities;
using Volunteer.MainModule.Managers.Filters;
using Volunteer.MainModule.Managers.Implementations;
using Volunteer.MainModule.RatingAPI;
using Volunteer.RatingSystem.RatingDetails.Models;
using Volunteer.RatingSystem.RatingDetails.MonitoringManager;

namespace Volunteer.RatingSystem.RaitingCalculators
{
    public class ActivityRatingCalculator : IRatingCalculator<Activity>
    {
        private readonly ActivityManager activityManager;
        private readonly ActivityRatingDetailsManager activityRatingDetailsManager;


        public ActivityRatingCalculator(ActivityManager activityManager, ActivityRatingDetailsManager activityRatingDetailsManager)
        {
            this.activityManager = activityManager;
            this.activityRatingDetailsManager = activityRatingDetailsManager;
        }

        public double GetRating(Guid activityUid)
        {
            var detail = activityRatingDetailsManager.Find(new Filter(nameof(ActivityRatingDetail.ActivityUid), activityUid)).FirstOrDefault();
            if (detail == null)
            {
                return default(double);
            }

            return detail.SelfMarkRating + detail.ViewingDuration.Select(t => t.Seconds).Average(); 
        }
    }
}
