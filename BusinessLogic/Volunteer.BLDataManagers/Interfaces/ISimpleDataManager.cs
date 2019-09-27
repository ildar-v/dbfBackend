namespace Volunteer.BLDataManagers.Interfaces
{
    using System.Collections.Generic;
    using BLModels.Interfaces;

    public interface ISimpleDataManager<T> where T: IEntity
    {
        T Find(IDictionary<string, object> searchParams);
        void Save(T entity);
    }
}
