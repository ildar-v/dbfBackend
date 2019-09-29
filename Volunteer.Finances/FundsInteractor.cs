namespace Volunteer.Finances
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text;
    using Volunteer.Finances.Managers;
    using Volunteer.Finances.Models;
    using Volunteer.MainModule.Managers;
    using Volunteer.MainModule.Managers.Filters;
    using Volunteer.BLModels.Entities;

    public class FundsInteractor
    {
        private readonly ISimpleManager<Fund> fundManager;
        private readonly ISimpleManager<CashFlow> cashFlowManager;
        private readonly ISimpleManager<Activity> activityManager;

        public FundsInteractor(ISimpleManager<Fund> fundManager,
                               ISimpleManager<CashFlow> cashFlowManager,
                               ISimpleManager<Activity> activityManager)
        {
            this.fundManager = fundManager;
            this.cashFlowManager = cashFlowManager;
            this.activityManager = activityManager;
        }

        public void NewCashFlow(decimal amount, Guid fundUid, Guid? activityUid)
        {
            var fund = this.fundManager.Find(new Filter(nameof(Fund.Uid), fundUid)).FirstOrDefault();

            if (fund == null)
                return;

            Activity activity = null;

            if(activityUid.HasValue)
            {
                activity = this.activityManager.Find(new Filter(nameof(Activity.Uid), fundUid)).FirstOrDefault();

                if (activity == null)
                    return;
            }

            var cashFlow = new CashFlow
            {
                Uid = Guid.NewGuid(),
                Amount = amount,
                Fund = fund,
                Activity = activity,
                DateTime = DateTime.Now
            };

            if(cashFlow.DateTime >= fund.StartDate && cashFlow.DateTime <= fund.EndDate)
            {
                if (this.cashFlowManager.Save(cashFlow))
                {
                    if (fund.CashFlows == null)
                        fund.CashFlows = new List<CashFlow>();

                    fund.CashFlows.Add(cashFlow);
                }
            }


        }

        public void NewFund(string title, string description, decimal budget, DateTime start, DateTime end)
        {
            this.fundManager.Save(new Fund
            {
                Uid = Guid.NewGuid(),
                Title = title,
                Description = description,
                Budget = budget,
                StartDate = start,
                EndDate = end,
                CashFlows = new List<CashFlow>()
            });
        }

        public IEnumerable<Fund> GetAllFunds()
        {
            return this.fundManager.Find();
        }

        public Fund FindByUid(Guid uid)
        {
            return this.fundManager.Find(new Filter(nameof(Fund.Uid), uid)).FirstOrDefault();
        }
    }
}
