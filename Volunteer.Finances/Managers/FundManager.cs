using System.Collections.Generic;
using Volunteer.Finances.Models;
using Volunteer.MainModule.Managers;
using Volunteer.MainModule.Managers.DataManagers;
using Volunteer.MainModule.Managers.Filters;

namespace Volunteer.Finances.Managers
{
    public class FundManager : ISimpleManager<Fund>
    {
        private readonly IDataManager<Fund> dataManager;

        public FundManager(IDataManager<Fund> dataManager)
        {
            this.dataManager = dataManager;
        }

        public IEnumerable<Fund> Find(Filter filter = null)
        {
            if (filter == null)
            {
                return this.dataManager.GetAll();
            }

            return dataManager.GetAll(a => filter.Check<Fund>(a));
        }

        public bool Save(Fund entity)
        {
            return this.dataManager.Save(entity);
        }
    }
}
