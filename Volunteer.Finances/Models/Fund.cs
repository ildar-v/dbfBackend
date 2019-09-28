using System;

namespace Volunteer.Finances.Models
{
    public class Fund
    {
        public Guid Uid { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
        
        public decimal Budget { get; set; }
    }
}
