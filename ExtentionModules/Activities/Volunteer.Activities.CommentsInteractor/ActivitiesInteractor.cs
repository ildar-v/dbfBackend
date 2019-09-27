namespace Volunteer.Activities.Interactor
{
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

        public ActivitiesInteractor(ISimpleManager<Comment> commentSimpleManager, ISimpleManager<Activity> activitySimpleManager)
        {
            this.commentSimpleManager = commentSimpleManager;
            this.activitySimpleManager = activitySimpleManager;
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
                result.Add(new ActivityDTO
                {
                    Activity = activity,
                    Comment = this.commentSimpleManager.Find(new Filter(new Dictionary<string, object[]>
                    {
                        { "EntityUid", new object[] { activity.Uid } },
                        { "EntityType", new object[] { typeof(Activity) } }
                    }))
                });
            }

            return result;
        }
    }
}
