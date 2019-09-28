namespace TempDAL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Volunteer.BLModels.Entities;
    using Volunteer.MainModule.Managers.DataManagers;

    public class ActivitiesUsersDataManager : IDataManager<ActivitiesUsers>
    {
        public static List<ActivitiesUsers> tempStore { get; set; }

        static ActivitiesUsersDataManager()
        {
            tempStore = new List<ActivitiesUsers>();
        }

        public IEnumerable<ActivitiesUsers> GetAll(Predicate<ActivitiesUsers> filterPredicate = null)
        {
            if (filterPredicate == null)
            {
                return tempStore;
            }

            return tempStore.Where(i => filterPredicate.Invoke(i));
        }

        public bool Save(ActivitiesUsers enitity)
        {
            var exists = tempStore.FirstOrDefault(i => i.Uid == enitity.Uid);
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
