using System;

namespace Volunteer.BLModels.Entities
{
    public class Mark
    {
        public Guid UserUid { get; set; }

        public Guid EntityUid { get; set; }

        public bool Flag { get; set; }
    }
}
