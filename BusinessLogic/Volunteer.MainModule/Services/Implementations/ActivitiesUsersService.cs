namespace Volunteer.MainModule.Services.Implementations
{
    using System.Collections.Generic;
    using Volunteer.BLModels.Entities;
    using Volunteer.MainModule.Managers;
    using Volunteer.MainModule.Managers.Filters;
    using Volunteer.MainModule.Services.Interfaces;

    public class ActivitiesUsersService : IActivitiesUsersService
    {
        private readonly ISimpleManager<ActivitiesUsers> activitiesUsersManager;

        public ActivitiesUsersService(ISimpleManager<ActivitiesUsers> activitiesUsersManager)
        {
            this.activitiesUsersManager = activitiesUsersManager;
        }

        public bool CreateOrUpdate(ActivitiesUsers entity)
        {
            return this.activitiesUsersManager.Save(entity);
        }

        public IEnumerable<ActivitiesUsers> Find(Filter filter = null)
        {
            return this.activitiesUsersManager.Find(filter);
        }
    }
}
