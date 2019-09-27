namespace TempDAL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Volunteer.BLModels.Entities;
    using Volunteer.MainModule.Managers.DataManagers;

    public class ActivityDataManager : IDataManager<Activity>
    {
        private static List<Activity> tempStore = new List<Activity>();

        public ActivityDataManager()
        {
            tempStore = new List<Activity>();
            tempStore.Add(new Activity
            {
                Uid = Guid.NewGuid(),
                Title = "Помыть окна бабке",
                Description = "Надо помыть бабке окна в Ижевске",
                Location = null,
                Rating = new Rating
                {
                    Uid = Guid.NewGuid(),
                    Value = 0
                },
                Report = null
            });
            tempStore.Add(new Activity
            {
                Uid = Guid.NewGuid(),
                Title = "Надо что-то сделать в Казани",
                Description = "Надо что-то сделать в Казани очень срочно",
                Location = null,
                Rating = new Rating
                {
                    Uid = Guid.NewGuid(),
                    Value = 5.5
                },
                Report = null
            });
        }

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
