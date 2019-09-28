using System;
using System.Collections.Generic;
using Volunteer.Finances.Models;

namespace Volunteer.Finances.Services.FundsService
{
    public interface IFundsService
    {
        Fund GetFundById(Guid uid);

        IEnumerable<Fund> GetAllFunds();

        bool Save(Fund fund);
    }
}
