using System;
using System.Collections.Generic;
using System.Linq;
using Volunteer.BLModels.Entities;
using Volunteer.MainModule.Managers.DataManagers;

namespace TempDAL
{
    public class ActivityDataManager : IDataManager<Activity>
    {
        private static List<Activity> tempStore = new List<Activity>()
        {
            new Activity()
            {
                Uid = Guid.NewGuid(),
                Description = "Какое-то описание",
                Rating = new Rating
                {
                    Uid = Guid.NewGuid(),
                    Value = 123,
                },
                Title = "Какое-то название"
            },
            new Activity()
            {
                Uid = Guid.NewGuid(),
                Description = "Какое-то описание-1",
                Rating = new Rating
                {
                    Uid = Guid.NewGuid(),
                    Value = 99,
                },
                Title = "Какое-то название-1"
            },
            new Activity()
            {
                Uid = Guid.NewGuid(),
                Description = "Какое-то описание-2",
                Rating = new Rating
                {
                    Uid = Guid.NewGuid(),
                    Value = 93,
                },
                Title = "Какое-то название-2"
            }
        };

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
