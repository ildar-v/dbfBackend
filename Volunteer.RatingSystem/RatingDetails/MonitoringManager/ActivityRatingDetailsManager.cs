using System.Collections.Generic;
using Volunteer.MainModule.Managers;
using Volunteer.MainModule.Managers.DataManagers;
using Volunteer.MainModule.Managers.Filters;
using Volunteer.RatingSystem.RatingDetails.Models;

namespace Volunteer.RatingSystem.RatingDetails.MonitoringManager
{
    public class ActivityRatingDetailsManager : ISimpleManager<ActivityRatingDetail>
    {
        private readonly IDataManager<ActivityRatingDetail> dataManager;

        public ActivityRatingDetailsManager(IDataManager<ActivityRatingDetail> dataManager)
        {
            this.dataManager = dataManager;
        }

        public IEnumerable<ActivityRatingDetail> Find(Filter filter = null)
        {
            if (filter == null)
            {
                return dataManager.GetAll();
            }
            return dataManager.GetAll(a => filter.Check<ActivityRatingDetail>(a));
        }

        public bool Save(ActivityRatingDetail entity)
        {
            return dataManager.Save(entity);
        }
    }
}
