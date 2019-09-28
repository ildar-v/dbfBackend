using System;
using System.Collections.Generic;
using System.Linq;
using Volunteer.BLModels.Entities;
using Volunteer.MainModule.Managers.DataManagers;

namespace TempDAL
{
    public class UserDataManager : IDataManager<User>
    {
        private static List<User> tempStore = new List<User>();

        public UserDataManager()
        {
            tempStore = new List<User>();
            tempStore.Add(new User
            {
                Uid = new Guid("e281797e-1425-4b21-8650-3407d01cea00"),
                Login = "Max",
                FullName = "Карабаев Максим Олегович",
                PasswordHash = "123456",
                ActivitiesUsers = new List<ActivitiesUsers>
                {
                    new ActivitiesUsers
                    {
                        Uid = Guid.NewGuid()
                    }
                },
                About = "Это Карабаев Максим Олегович - программист RDDS",
                AvatarUrl = "https://avatars.mds.yandex.net/get-pdb/28866/bc1b684a-8405-4c23-b76a-25648d529c52/s1200"
            });
            tempStore.Add(new User
            {
                Uid = new Guid("4db193ce-c7c4-4674-99c8-9c2e9bd5ee9a"),
                Login = "Ild",
                FullName = "Вазетдинов Ильдар Радулевич",
                PasswordHash = "123456",
                ActivitiesUsers = new List<ActivitiesUsers>
                {
                    new ActivitiesUsers
                    {
                        Uid = Guid.NewGuid()
                    }
                },
                About = "Это Ильдар - воображаемый друг",
                AvatarUrl = "https://avatars.mds.yandex.net/get-pdb/480866/719d9723-eac6-40c8-aab3-3c71a0b25a1e/s1200"
            });
        }

        public IEnumerable<User> GetAll(Predicate<User> filterPredicate = null)
        {
            if (filterPredicate == null)
            {
                return tempStore;
            }

            return tempStore.Where(i => filterPredicate.Invoke(i));
        }

        public bool Save(User enitity)
        {
            var exists = tempStore.FirstOrDefault(i => i.Uid == enitity.Uid);
            if (exists == null)
            {
                tempStore.Add(enitity);
            }
            else
            {
                tempStore.Remove(exists);
                tempStore.Add(enitity);
            }
            return true;
        }
    }
}
