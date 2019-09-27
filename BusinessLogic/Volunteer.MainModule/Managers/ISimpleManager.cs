using System.Collections.Generic;
using Volunteer.MainModule.Managers.DataManagers.Filters;

namespace Volunteer.MainModule.Managers
{
    public interface ISimpleManager<T>
    {
        IEnumerable<T> Find(Filter filter);
        bool Save(T entity);
    }
}
