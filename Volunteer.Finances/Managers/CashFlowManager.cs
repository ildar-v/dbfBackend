namespace Volunteer.Finances.Managers
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using MainModule.Managers;
    using Finances.Models;
    using MainModule.Managers.DataManagers;
    using MainModule.Managers.Filters;

    public class CashFlowManager : ISimpleManager<CashFlow>
    {
        private readonly IDataManager<CashFlow> dataManager;

        public CashFlowManager(IDataManager<CashFlow> dataManager)
        {
            this.dataManager = dataManager;
        }

        public IEnumerable<CashFlow> Find(Filter filter = null)
        {
            if (filter == null)
            {
                return this.dataManager.GetAll();
            }

            return dataManager.GetAll(a => filter.Check<Fund>(a));
        }

        public bool Save(CashFlow entity)
        {
            return this.dataManager.Save(entity);
        }
    }
}
