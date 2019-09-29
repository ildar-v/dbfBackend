namespace Volunteer.Api.ViewModels.Finance
{
    using System;

    public class FundViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Budget { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
