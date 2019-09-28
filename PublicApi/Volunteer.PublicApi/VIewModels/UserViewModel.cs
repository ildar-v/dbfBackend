namespace Volunteer.PublicApi.VIewModels
{
    using System;

    public class UserViewModel
    {
        public Guid Uid { get; set; }
        public string FullName { get; set; }
        public string AvatarUrl { get; set; }
        public string About { get; set; }
    }
}
