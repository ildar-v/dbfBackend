namespace Volunteer.Finances.Models
{
    using System;
    using BLModels.Entities;

    public class CashFlow
    {
        public Guid Uid { get; set; }
        public Fund Fund { get; set; }
        public decimal Amount { get; set; }
        public Activity Activity { get; set; }
        public DateTime DateTime { get; set; }
    }
}
