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
    using AutoMapper;
    using BLModels.Enums;

    public class ActivitiesInteractor
    {
        private readonly ISimpleManager<Comment> commentSimpleManager;
        private readonly ISimpleManager<Activity> activitySimpleManager;
        private readonly ISimpleManager<ActivitiesUsers> activitiesUsersSimpleManager;
        private readonly ISimpleManager<User> userSimpleManager;
        private readonly IMapper mapper;

        public ActivitiesInteractor(ISimpleManager<Comment> commentSimpleManager,
                                    ISimpleManager<Activity> activitySimpleManager,
                                    ISimpleManager<ActivitiesUsers> activitiesUsersSimpleManager,
                                    ISimpleManager<User> userSimpleManager,
                                    IMapper mapper)
        {
            this.commentSimpleManager = commentSimpleManager;
            this.activitySimpleManager = activitySimpleManager;
            this.activitiesUsersSimpleManager = activitiesUsersSimpleManager;
            this.userSimpleManager = userSimpleManager;
            this.mapper = mapper;
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
                    Comments = this.commentSimpleManager.Find(new Filter(new Dictionary<string, object[]>
                    {
                        { "EntityUid", new object[] { activity.Uid } },
                        { "EntityType", new object[] { typeof(Activity) } }
                    }))
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

        public bool Save(ActivityCreateDTO entity)
        {
            var activity = this.mapper.Map<Activity>(entity);
            activity.Uid = Guid.NewGuid();
            activity.AddDateTime = DateTime.Now;
            List<ActivitiesUsers> roles = new List<ActivitiesUsers>();

            if(entity.AuthorUids == null)
            {
                throw new ArgumentOutOfRangeException(nameof(entity.AuthorUids));
            }

            foreach (var item in entity.AuthorUids)
            {
                User user = this.userSimpleManager.Find()?.FirstOrDefault(a => a.Uid == item);

                if(user != null)
                {
                    roles.Add(new ActivitiesUsers
                    {
                        Uid = Guid.NewGuid(),
                        Activity = activity,
                        User = user,
                        UserType = UserTypes.Organizer
                    });
                }
            }

            if(this.activitySimpleManager.Save(activity))
            {
                foreach (var item in roles)
                {
                    this.activitiesUsersSimpleManager.Save(item);
                }
            }

            return true;
        }
    }
}
