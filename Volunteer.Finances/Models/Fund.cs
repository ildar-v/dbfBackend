namespace Volunteer.Finances.Models
{
    using System;
    using System.Collections.Generic;

    public class Fund
    {
        public Guid Uid { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ICollection<CashFlow> CashFlows { get; set; }
    }
}
