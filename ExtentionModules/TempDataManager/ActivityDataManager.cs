﻿namespace TempDAL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Volunteer.BLModels.Entities;
    using Volunteer.MainModule.Managers.DataManagers;

    public class ActivityDataManager : IDataManager<Activity>
    {
        public static List<Activity> tempStore { get; set; }

        public IEnumerable<Activity> GetAll(Predicate<Activity> filterPredicate = null)
        {
            if (filterPredicate == null)
            {
                return tempStore;
            }

            return tempStore.Where(i => filterPredicate.Invoke(i));
        }

        public bool Save(Activity enitity)
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
