namespace Volunteer.Comments.Manager
{
    using System.Collections.Generic;
    using MainModule.Managers;
    using Comments.Entity;
    using MainModule.Managers.Filters;
    using MainModule.Managers.DataManagers;

    public class CommentsManager : ISimpleManager<Comment>
    {
        private readonly IDataManager<Comment> dataManager;

        public CommentsManager(IDataManager<Comment> dataManager)
        {
            this.dataManager = dataManager;
        }

        public IEnumerable<Comment> Find(Filter filter = null)
        {
            if (filter == null)
            {
                this.dataManager.GetAll();
            }

            return dataManager.GetAll(a => filter.Check<Comment>(a));
        }

        public bool Save(Comment entity)
        {
            return this.dataManager.Save(entity);
        }
    }
}
