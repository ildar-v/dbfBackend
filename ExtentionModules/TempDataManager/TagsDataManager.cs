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

        public bool Save(Tag tagNewUpdate)
        {
            var tag = tempStore.FirstOrDefault(i => i.Name == tagNewUpdate.Name);
            if (tag == null)
            {
                tempStore.Add(tag);
                return true;
            }

            var entityUid = tag.EntityUids.FirstOrDefault();
            var exists = tag.EntityUids.Any(x => x == entityUid);
            if (!exists)
            {
                tag.EntityUids.Add(entityUid);
                return true;
            }
            return false;
        }
    }
}
