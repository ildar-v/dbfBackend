namespace Volunteer.Finances.Services.CashFlowService
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Models;
    using MainModule.Managers;
    using MainModule.Managers.Filters;

    public class CashFlowService : ICashFlowService
    {
        private readonly ISimpleManager<CashFlow> manager;

        public CashFlowService(ISimpleManager<CashFlow> manager)
        {
            this.manager = manager;
        }

        public IEnumerable<CashFlow> GetAll()
        {
            return this.manager.Find();
        }

        public CashFlow FindByUid(Guid uid)
        {
            return this.manager.Find(new Filter(nameof(CashFlow.Uid), uid)).FirstOrDefault();
        }

        public bool Save(CashFlow entity)
        {
            return this.manager.Save(entity);
        }
    }
}
