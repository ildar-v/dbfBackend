using System.Collections.Generic;
using Volunteer.MainModule.Managers;
using Volunteer.MainModule.Managers.DataManagers;
using Volunteer.MainModule.Managers.Filters;
using Volunteer.Tags.Models;

namespace Volunteer.Tags.Managers
{
    public class TagManager : ISimpleManager<Tag>
    {
        private readonly IDataManager<Tag> dataManager;

        public TagManager(IDataManager<Tag> dataManager)
        {
            this.dataManager = dataManager;
        }

        public IEnumerable<Tag> Find(Filter filter = null)
        {
            if (filter == null)
            {
                this.dataManager.GetAll();
            }

            return dataManager.GetAll(a => filter.Check<Tag>(a));
        }

        public bool Save(Tag entity)
        {
            return this.dataManager.Save(entity);
        }
    }
}
