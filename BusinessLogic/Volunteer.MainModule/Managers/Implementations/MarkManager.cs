namespace Volunteer.MainModule.Managers.Implementations
{
    using System.Collections.Generic;
    using Volunteer.BLModels.Entities;
    using Volunteer.MainModule.Managers.Filters;
    using DataManagers;

    public class MarkManager : ISimpleManager<Mark>
    {
        private readonly IDataManager<Mark> dataManager;

        public MarkManager(IDataManager<Mark> dataManager)
        {
            this.dataManager = dataManager;
        }

        public IEnumerable<Mark> Find(Filter filter = null)
        {
            if (filter == null)
            {
                return this.dataManager.GetAll();
            }

            return dataManager.GetAll(a => filter.Check<Mark>(a));
        }

        public bool Save(Mark entity)
        {
            return this.dataManager.Save(entity);
        }
    }
}
