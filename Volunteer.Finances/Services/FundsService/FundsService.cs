using System;
using System.Linq;
using Volunteer.Finances.Models;
using Volunteer.MainModule.Managers;
using Volunteer.MainModule.Managers.Filters;

namespace Volunteer.Finances.Services.FundsService
{
    public class FundsService : IFundsService
    {
        private readonly ISimpleManager<Fund> fundManager;

        public FundsService(ISimpleManager<Fund> fundManager)
        {
            this.fundManager = fundManager;
        }

        public System.Collections.Generic.IEnumerable<Fund> GetAllFunds()
        {
            return fundManager.Find();
        }

        public Fund GetFundById(Guid uid)
        {
            return fundManager.Find(new Filter(nameof(Fund.Uid), uid)).FirstOrDefault();
        }

        public bool Save(Fund fund)
        {
            if(fund == null || fund.Uid == Guid.Empty || string.IsNullOrWhiteSpace(fund.Title))
            {
                return false;
            }

            return fundManager.Save(fund);
        }
    }
}
