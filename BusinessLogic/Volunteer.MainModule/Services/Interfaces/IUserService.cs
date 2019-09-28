namespace Volunteer.MainModule.Services.Interfaces
{
    using System;
    using DTO;

    public interface IUserService : IService<UserDTO>
    {
        UserDTO FindByLogin(string login);
        UserDTO FindByUid(Guid uid);
        UserDTO FindScalarByUidOrLogin(string searchStr);
    }
}
