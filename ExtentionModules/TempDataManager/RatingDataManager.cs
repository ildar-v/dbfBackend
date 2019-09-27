namespace TempDAL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Volunteer.BLModels.Entities;
    using Volunteer.MainModule.Managers.DataManagers;

    public class RatingDataManager : IDataManager<Rating>
    {
        private static List<Rating> tempStore = new List<Rating>();

        RatingDataManager()
        {
            tempStore = new List<Rating>();
            tempStore.Add(new Rating
            {
                Uid = Guid.NewGuid(),
                Value = 1
            });
            tempStore.Add(new Rating
            {
                Uid = Guid.NewGuid(),
                Value = 5.5
            });
        }

        public IEnumerable<Rating> GetAll(Predicate<Rating> filterPredicate = null)
        {
            if (filterPredicate == null)
            {
                return tempStore;
            }

            return tempStore.Where(i => filterPredicate.Invoke(i));
        }

        public bool Save(Rating enitity)
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
