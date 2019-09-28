using System;
using System.Collections.Generic;
using Volunteer.BLModels.Entities;

namespace Volunteer.MainModule.Services.Interfaces
{
    public interface IMarkService
    {
        IEnumerable<Mark> GetMarksByEntityUid(Guid uid);

        bool SaveMark(Mark mark);
    }
}
