using System;
using System.Collections.Generic;
using Volunteer.BLModels.Entities;

namespace Volunteer.MainModule.Services.Interfaces
{
    public interface IMarkService
    {
        Mark GetMark(Guid userUid, Guid entityUid);

        int GetRaiting(Guid entityUid);

        bool SaveMark(Mark mark);
    }
}
