namespace Volunteer.MainModule.Services.Implementations
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using BLModels.Entities;
    using MainModule.Services.Interfaces;
    using MainModule.Managers.Filters;
    using MainModule.Managers;
    using DTO;
    using AutoMapper;

    public class UserService : IUserService
    {
        private readonly ISimpleManager<User> userManager;
        private readonly IMapper mapper;

        public UserService(ISimpleManager<User> userManager, IMapper mapper)
        {
            this.userManager = userManager;
            this.mapper = mapper;
        }

        public bool CreateOrUpdate(UserDTO entity)
        {
            var user = mapper.Map<User>(entity);
            return this.userManager.Save(user);
        }

        public IEnumerable<UserDTO> Find(Filter filter = null)
        {
            var users = this.userManager.Find(filter);
            var result = this.mapper.Map<IEnumerable<UserDTO>>(users);
            return result;
        }

        public UserDTO FindByLogin(string login)
        {
            if (string.IsNullOrWhiteSpace(login))
            {
                throw new ArgumentNullException(nameof(login));
            }

            var result = this.userManager.Find(new Filter("Login", login))?.ToList();

            if(result != null && result.Any())
            {
                var userDto = this.mapper.Map<UserDTO>(result[0]);
                return userDto;
            }

            return null;
        }
    }
}
