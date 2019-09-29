namespace Volunteer.Api.ViewModels.Finance
{
    using System;

    public class CashFlowViewModel
    {
        public decimal Amount { get; set; }
        public DateTime DateTime { get; set; }
        public string ActivityTitle { get; set; }
        public string FundTitle { get; set; }
    }
}
