namespace Volunteer.Activities.Interactor
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Comments.Entity;
    using BLModels.Entities;
    using MainModule.Managers;
    using MainModule.Managers.Filters;
    using Activities.DTO;

    public class ActivitiesInteractor
    {
        private readonly ISimpleManager<Comment> commentSimpleManager;
        private readonly ISimpleManager<Activity> activitySimpleManager;
        private readonly ISimpleManager<Mark> activityMarkManager;

        public ActivitiesInteractor(ISimpleManager<Comment> commentSimpleManager,
            ISimpleManager<Activity> activitySimpleManager, ISimpleManager<Mark> activityMarkManager)
        {
            this.commentSimpleManager = commentSimpleManager;
            this.activitySimpleManager = activitySimpleManager;
            this.activityMarkManager = activityMarkManager;
        }

        public IEnumerable<ActivityDTO> Find(Filter filter = null)
        {
            var activities = this.activitySimpleManager.Find(filter);
            var result = new List<ActivityDTO>();

            if(activities == null)
            {
                return null;
            }

            foreach (var activity in activities)
            {
                var activityMark = 0;
                var marks = this.activityMarkManager.Find(new Filter(new Dictionary<string, object[]>
                    {
                        { "EntityUid", new object[] { activity.Uid } },
                    }));
                foreach (var mark in marks)
                {
                    activityMark += mark.Flag ? 1 : -1;
                }

                result.Add(new ActivityDTO
                {
                    Activity = activity,
                    Comments = this.commentSimpleManager.Find(new Filter(new Dictionary<string, object[]>
                    {
                        { "EntityUid", new object[] { activity.Uid } },
                        { "EntityType", new object[] { typeof(Activity) } }
                    })),
                    Mark = activityMark
                });
            }

            return result;
        }

        public ActivityDTO FindScalarByUid(Guid uid)
        {
            var activity = this.activitySimpleManager.Find()?.FirstOrDefault(a => a.Uid == uid);

            if(activity != null)
            {
                var result = new ActivityDTO
                {
                    Activity = activity,
                    Comments = commentSimpleManager.Find(new Filter(new Dictionary<string, object[]>
                    {
                        { "EntityUid", new object[] { activity.Uid } },
                        { "EntityType", new object[] { typeof(Activity) } }
                    }))
                };

                return result;
            }

            return null;
        }
    }
}
