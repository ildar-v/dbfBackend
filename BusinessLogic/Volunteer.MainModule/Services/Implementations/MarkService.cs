using System;
using System.Collections.Generic;
using System.Linq;
using Volunteer.BLModels.Entities;
using Volunteer.MainModule.Managers;
using Volunteer.MainModule.Managers.Filters;
using Volunteer.MainModule.Services.Interfaces;

namespace Volunteer.MainModule.Services.Implementations
{
    public class MarkService : IMarkService
    {
        private readonly ISimpleManager<Mark> markManager;
        private readonly ISimpleManager<Mark> activityMarkManager;

        public MarkService(ISimpleManager<Mark> markManager, ISimpleManager<Mark> activityMarkManager)
        {
            this.markManager = markManager;
            this.activityMarkManager = activityMarkManager;
        }

        public Mark GetMark(Guid userUid, Guid entityUid)
        {
            if (userUid == Guid.Empty || entityUid == Guid.Empty)
            {
                return null;
            }
            var filter = new Filter(
                new Dictionary<string, object[]>
                {
                    { nameof(Mark.UserUid), new object[] { userUid } },
                    { nameof(Mark.EntityUid), new object[] { entityUid } },
                });
            return markManager.Find(filter).FirstOrDefault();
        }

        public int GetRaiting(Guid entityUid)
        {
            var activityMark = 0;
            var marks = this.activityMarkManager.Find(new Filter(new Dictionary<string, object[]>
                    {
                        { "EntityUid", new object[] { entityUid } },
                    }));
            foreach (var mark in marks)
            {
                activityMark += mark.Flag ? 1 : -1;
            }
            return activityMark;
        }

        public bool SaveMark(Mark mark)
        {
            return markManager.Save(mark);
        }
    }
}
