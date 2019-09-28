namespace Volunteer.Authentity.Model
{
    public class RegisterModel
    {
        public string FullName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string RepeatPassword { get; set; }
        public string AvatarUrl { get; set; }
        public string About { get; set; }
    }
}
