
namespace Volunteer.Comments.DataManager
{
    using System;
    using System.Collections.Generic;
    using MainModule.Managers.DataManagers;
    using Comments.Entity;
    using System.Linq;

    public class CommentDataManager : IDataManager<Comment>
    {
        public static IList<Comment> tempStore { get; set; }

        public IEnumerable<Comment> GetAll(Predicate<Comment> filterPredicate = null)
        {
            if (filterPredicate == null)
            {
                return tempStore;
            }

            return tempStore.Where(i => filterPredicate.Invoke(i));
        }

        public bool Save(Comment enitity)
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
