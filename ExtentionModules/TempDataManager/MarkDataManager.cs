namespace TempDAL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Volunteer.BLModels.Entities;
    using Volunteer.MainModule.Managers.DataManagers;

    public class MarkDataManager : IDataManager<Mark>
    {
        public static List<Mark> tempStore;

        public IEnumerable<Mark> GetAll(Predicate<Mark> filterPredicate = null)
        {
            if (filterPredicate == null)
            {
                return tempStore;
            }

            return tempStore.Where(i => filterPredicate.Invoke(i));
        }

        public bool Save(Mark mark)
        {
            var exists = tempStore.FirstOrDefault(i => i.UserUid == mark.UserUid && i.EntityUid == mark.EntityUid);
            if (exists == null)
            {
                tempStore.Add(mark);
            }
            else
            {
                tempStore.Remove(exists);
                tempStore.Add(mark);
            }
            return true;
        }
    }
}
