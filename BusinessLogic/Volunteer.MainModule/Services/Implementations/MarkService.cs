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

        public MarkService(ISimpleManager<Mark> markManager)
        {
            this.markManager = markManager;
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

        public bool SaveMark(Mark mark)
        {
            if (mark.EntityUid == Guid.Empty || mark.UserUid == Guid.Empty)
            {
                return false;
            }
            return markManager.Save(mark);
        }
    }
}
