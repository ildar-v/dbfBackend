namespace Volunteer.Api.ViewModels
{
    using System;

    public class UserDetailViewModel
    {
        public Guid Uid { get; set; }
        public string FullName { get; set; }
        public RatingViewModel Rating { get; set; }
        public string AvatarUrl { get; set; }
        public string About { get; set; }
    }
}
