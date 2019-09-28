namespace Volunteer.DTO
{
    using System;

    public class UserDTO
    {
        public Guid Uid { get; set; }
        public string FullName { get; set; }
        public string Login { get; set; }
        public string PasswordHash { get; set; }
       // public ICollection<ActivitiesUsers> ActivitiesUsers { get; set; } todo: реализовать выгрузку этого поля
        public RatingDTO Rating { get; set; }
        public string AvatarUrl { get; set; }
        public string About { get; set; }

    }
}
