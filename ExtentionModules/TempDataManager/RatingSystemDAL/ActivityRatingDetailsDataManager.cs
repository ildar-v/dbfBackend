using System;
using System.Collections.Generic;
using System.Linq;
using Volunteer.MainModule.Managers.DataManagers;
using Volunteer.RatingSystem.RatingDetails.Models;

namespace TempDAL.RatingSystemDAL
{
    public class ActivityRatingDetailsDataManager : IDataManager<ActivityRatingDetail>
    {
        private static List<ActivityRatingDetail> tempStore = new List<ActivityRatingDetail>();

        public IEnumerable<ActivityRatingDetail> GetAll(Predicate<ActivityRatingDetail> filterPredicate = null)
        {
            if (filterPredicate == null)
            {
                return tempStore;
            }

            return tempStore.Where(i => filterPredicate.Invoke(i));
        }

        public bool Save(ActivityRatingDetail enitity)
        {
            var exists = tempStore.FirstOrDefault(i => i.ActivityUid == enitity.ActivityUid);
            if (exists == null)
            {
                tempStore.Add(enitity);
            }
            else
            {
                tempStore.Remove(exists);
                tempStore.Add(enitity);
            }
            return true;
        }
    }
}
