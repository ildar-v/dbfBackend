using System;
using System.Collections.Generic;
using System.Linq;
using Volunteer.Finances.Models;
using Volunteer.MainModule.Managers.DataManagers;

namespace TempDAL.FinanceSystemDAL
{
    public class FundDataManager : IDataManager<Fund>
    {
        private static List<Fund> tempStore = new List<Fund>();

        public IEnumerable<Fund> GetAll(Predicate<Fund> filterPredicate = null)
        {
            if (filterPredicate == null)
            {
                return tempStore;
            }

            return tempStore.Where(i => filterPredicate.Invoke(i));
        }

        public bool Save(Fund enitity)
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
