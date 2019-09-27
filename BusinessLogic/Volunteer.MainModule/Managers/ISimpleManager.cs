using System.Collections.Generic;
using Volunteer.MainModule.Managers.Filters;

namespace Volunteer.MainModule.Managers
{
    public interface ISimpleManager<T>
    {
        IEnumerable<T> Find(Filter filter = null);
        bool Save(T entity);
    }
}
