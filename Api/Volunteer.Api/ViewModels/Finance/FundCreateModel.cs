﻿namespace Volunteer.Api.ViewModels.Finance
{
    using System;

    public class FundCreateModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
