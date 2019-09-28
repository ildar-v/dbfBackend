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
        private readonly ISimpleManager<Mark> activityMarkManager;
        private readonly IMapper mapper;

        public ActivitiesInteractor(ISimpleManager<Comment> commentSimpleManager,
                                    ISimpleManager<Activity> activitySimpleManager,
                                    ISimpleManager<ActivitiesUsers> activitiesUsersSimpleManager,
                                    ISimpleManager<User> userSimpleManager,
                                    ISimpleManager<Mark> activityMarkManager,
                                    IMapper mapper)
        {
            this.commentSimpleManager = commentSimpleManager;
            this.activitySimpleManager = activitySimpleManager;
            this.activitiesUsersSimpleManager = activitiesUsersSimpleManager;
            this.userSimpleManager = userSimpleManager;
            this.activityMarkManager = activityMarkManager;
            this.mapper = mapper;
        }

        public IEnumerable<ActivityDTO> Find(Filter filter = null)
        {
            var activities = this.activitySimpleManager.Find(filter);
            var result = new List<ActivityDTO>();

            if (activities == null)
            {
                return null;
            }

            foreach (var activity in activities)
            {
                var activitiesUsers = this.activitiesUsersSimpleManager.Find(new Filter("ActivityGuid", new object[] { activity.Uid }));
                var volunteerUids = activitiesUsers
                    .Where(x => x.UserType == UserTypes.Volunteer)
                    .Select(x => x.Uid);
                var organizerUids = activitiesUsers
                    .Where(x => x.UserType == UserTypes.Organizer)
                    .Select(x => x.Uid);
                var volunteer = this.userSimpleManager.Find(new Filter("Uid", new object[] { volunteerUids }));
                var organizer = this.userSimpleManager.Find(new Filter("Uid", new object[] { organizerUids }));

                result.Add(new ActivityDTO
                {
                    Activity = activity,
                    Comments = this.commentSimpleManager.Find(new Filter(new Dictionary<string, object[]>
                    {
                        { "EntityUid", new object[] { activity.Uid } },
                        { "EntityType", new object[] { typeof(Activity) } }
                    })),
                    Volunteers = volunteer,
                    Organizers = organizer,
                    Mark = GetMark(activity)
                });
            }

            return result;
        }

        public ActivityDTO FindScalarByUid(Guid uid)
        {
            var activity = this.activitySimpleManager.Find()?.FirstOrDefault(a => a.Uid == uid);

            if (activity != null)
            {
                var result = new ActivityDTO
                {
                    Activity = activity,
                    Comments = commentSimpleManager.Find(new Filter(new Dictionary<string, object[]>
                    {
                        { "EntityUid", new object[] { activity.Uid } },
                        { "EntityType", new object[] { typeof(Activity) } }
                    })),
                    Mark = GetMark(activity)
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

            if (entity.AuthorUids == null)
            {
                throw new ArgumentOutOfRangeException(nameof(entity.AuthorUids));
            }

            foreach (var item in entity.AuthorUids)
            {
                User user = this.userSimpleManager.Find()?.FirstOrDefault(a => a.Uid == item);

                if (user != null)
                {
                    roles.Add(new ActivitiesUsers
                    {
                        Uid = Guid.NewGuid(),
                        ActivityGuid = activity.Uid,
                        UserGuid = user.Uid,
                        UserType = UserTypes.Organizer
                    });
                }
            }

            if (this.activitySimpleManager.Save(activity))
            {
                foreach (var item in roles)
                {
                    this.activitiesUsersSimpleManager.Save(item);
                }
            }

            return true;
        }

        private int GetMark(Activity activity)
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
            return activityMark;
        }
    }
}
