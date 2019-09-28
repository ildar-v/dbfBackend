namespace Volunteer.Api.ViewModels
{
    using System;

    public class UserViewModel
    {
        public Guid Uid { get; set; }
        public string FullName { get; set; }
        public RatingViewModel Rating { get; set; }
        public string AvatarUrl { get; set; }
        public string About { get; set; }
    }
}
