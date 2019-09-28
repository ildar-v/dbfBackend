namespace Volunteer.MainModule.Services.Interfaces
{
    using DTO;

    public interface IUserService : IService<UserDTO>
    {
        UserDTO FindByLogin(string login);
    }
}
