namespace Volunteer.MainModule.Managers.Implementations
{
    using System.Collections.Generic;
    using Volunteer.MainModule.Managers.DataManagers;
    using Volunteer.BLModels.Entities;
    using Volunteer.MainModule.Managers.Filters;

    public class ActivitiesUsersManager : ISimpleManager<ActivitiesUsers>
    {
        private IDataManager<ActivitiesUsers> dataManager;

        public ActivitiesUsersManager(IDataManager<ActivitiesUsers> dataManager)
        {
            this.dataManager = dataManager;
        }

        public IEnumerable<ActivitiesUsers> Find(Filter filter = null)
        {
            if (filter == null)
            {
                return dataManager.GetAll();
            }
            return dataManager.GetAll(a => filter.Check<ActivitiesUsers>(a));
        }

        public bool Save(ActivitiesUsers entity)
        {
            return dataManager.Save(entity);
        }
    }
}
