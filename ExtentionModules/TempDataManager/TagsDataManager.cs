using System;
using System.Collections.Generic;
using System.Linq;
using Volunteer.MainModule.Managers.DataManagers;
using Volunteer.Tags.Models;

namespace TempDAL
{
    public class TagsDataManager : IDataManager<Tag>
    {
        public static List<Tag> tempStore = new List<Tag>();

        public IEnumerable<Tag> GetAll(Predicate<Tag> filterPredicate = null)
        {
            if (filterPredicate == null)
            {
                return tempStore;
            }

            return tempStore.Where(i => filterPredicate.Invoke(i));
        }

        public bool Save(Tag enitity)
        {
            var exists = tempStore.FirstOrDefault(i => i.Name == enitity.Name);
            if (exists == null)
            {
                tempStore.Add(enitity);
                return true;
            }
            return false;
        }
    }
}
