namespace Volunteer.Finances.Services.CashFlowService
{
    using System;
    using System.Collections.Generic;
    using Models;

    public interface ICashFlowService
    {
        CashFlow FindByUid(Guid uid);

        IEnumerable<CashFlow> GetAll();

        bool Save(CashFlow entity);
    }
}
