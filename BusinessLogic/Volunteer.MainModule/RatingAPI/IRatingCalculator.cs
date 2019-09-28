using System;
using Volunteer.BLModels.Interfaces;

namespace Volunteer.MainModule.RatingAPI
{
    public interface IRatingCalculator<T> where T: IEntity
    {
        double GetRating(Guid activityUid);
    }
}
