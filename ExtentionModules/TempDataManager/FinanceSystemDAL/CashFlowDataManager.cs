namespace TempDAL.FinanceSystemDAL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Volunteer.Finances.Models;
    using Volunteer.MainModule.Managers.DataManagers;

    public class CashFlowDataManager : IDataManager<CashFlow>
    {
        public static List<CashFlow> tempStore = new List<CashFlow>();

        public IEnumerable<CashFlow> GetAll(Predicate<CashFlow> filterPredicate = null)
        {
            if (filterPredicate == null)
            {
                return tempStore;
            }

            return tempStore.Where(i => filterPredicate.Invoke(i));
        }

        public bool Save(CashFlow enitity)
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
