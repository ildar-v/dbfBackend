using System;
using System.Collections.Generic;
using Volunteer.BLModels.Entities;
using Volunteer.BLModels.Interfaces;
using Volunteer.MainModule.Managers.Filters;
using Volunteer.MainModule.Managers.Implementations;
using Volunteer.MainModule.Services.Interfaces;

namespace Volunteer.MainModule.Services.Implementations
{
    public class MarkService : IMarkService
    {
        private readonly MarkManager markManager;

        public MarkService(MarkManager markManager)
        {
            this.markManager = markManager;
        }

        public IEnumerable<Mark> GetMarksByEntityUid(Guid uid)
        {
            if (uid == Guid.Empty)
            {
                return null;
            }
            return markManager.Find(new Filter(nameof(IEntity.Uid), uid));
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
