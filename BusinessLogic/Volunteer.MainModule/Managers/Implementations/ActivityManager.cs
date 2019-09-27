namespace Volunteer.MainModule.Managers.Implementations
{
    using System.Collections.Generic;
    using Volunteer.MainModule.Managers.DataManagers;
    using Volunteer.BLModels.Entities;
    using Volunteer.MainModule.Managers.Filters;

    public class ActivityManager : ISimpleManager<Activity>
    {
        private IDataManager<Activity> dataManager;
        public ActivityManager(IDataManager<Activity> dataManager)
        {
            this.dataManager = dataManager;
        }

        public IEnumerable<Activity> Find(Filter filter = null)
        {
            if (filter == null)
            {
                dataManager.GetAll();
            }
            return dataManager.GetAll(a => filter.Check<Activity>(a));
        }

        public bool Save(Activity entity)
        {
            return dataManager.Save(entity);
        }
    }
}
