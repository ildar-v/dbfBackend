namespace Volunteer.Api.ViewModels.Finance
{
    using System;
    using System.Collections.Generic;

    public class FundDetailViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Budget { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public IEnumerable<CashFlowViewModel> CashFlows { get; set; }
    }
}
