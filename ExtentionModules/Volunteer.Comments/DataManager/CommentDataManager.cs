
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

        public bool Save(Comment comment)
        {
            comment.Uid = new Guid();
            comment.AddDateTime = DateTime.Now;
            tempStore.Add(comment);
            return true;
        }
    }
}
