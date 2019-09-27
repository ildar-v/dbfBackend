namespace Volunteer.MainModule.Managers.Implementations
{
    using System.Collections.Generic;
    using Volunteer.BLModels.Entities;
    using Volunteer.MainModule.Managers.Filters;
    using DataManagers;

    public class RatingManager : ISimpleManager<Rating>
    {
        private readonly IDataManager<Rating> dataManager;

        public RatingManager(IDataManager<Rating> dataManager)
        {
            this.dataManager = dataManager;
        }

        public IEnumerable<Rating> Find(Filter filter = null)
        {
            if (filter == null)
            {
                this.dataManager.GetAll();
            }

            return dataManager.GetAll(a => filter.Check<Rating>(a));
        }

        public bool Save(Rating entity)
        {
            return this.dataManager.Save(entity);
        }
    }
}
