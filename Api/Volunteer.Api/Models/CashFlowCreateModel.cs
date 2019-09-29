namespace Volunteer.Api.Models
{
    using System;

    public class CashFlowCreateModel
    {
        public Guid FundUid { get; set; }
        public decimal Amount { get; set; }
    }
}
