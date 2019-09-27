using System;
using System.Collections.Generic;

namespace Volunteer.MainModule.Managers.DataManagers
{
    public interface IDataManager<T>
    {
        IEnumerable<T> GetAll(Predicate<T> filterPredicate = null);

        bool Save(T enitity);
    }
}
