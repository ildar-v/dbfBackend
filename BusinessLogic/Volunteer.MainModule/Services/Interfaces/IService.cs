namespace Volunteer.MainModule.Services.Interfaces
{
    using System.Collections.Generic;
    using MainModule.Managers.Filters;

    public interface IService<T>
    {
        bool CreateOrUpdate(T entity);
        IEnumerable<T> Find(Filter filter = null);
    }
}
