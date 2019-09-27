namespace Volunteer.MainModule.Managers.Implementations
{
    using System.Collections.Generic;
    using Volunteer.BLModels.Entities;
    using Volunteer.MainModule.Managers.Filters;
    using DataManagers;

    public class UserManager : ISimpleManager<User>
    {
        private readonly IDataManager<User> dataManager;

        public UserManager(IDataManager<User> dataManager)
        {
            this.dataManager = dataManager;
        }

        public IEnumerable<User> Find(Filter filter = null)
        {
            if (filter == null)
            {
                this.dataManager.GetAll();
            }

            return dataManager.GetAll(a => filter.Check<User>(a));
        }

        public bool Save(User entity)
        {
            return this.dataManager.Save(entity);
        }
    }

}
