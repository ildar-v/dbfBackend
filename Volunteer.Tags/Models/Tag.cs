using System;
using System.Collections.Generic;

namespace Volunteer.Tags.Models
{
    public class Tag
    {
        public string Name { get; set; }

        public List<Guid> EntityUids { get; set; }
    }
}
