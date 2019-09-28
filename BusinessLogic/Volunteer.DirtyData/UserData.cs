namespace Volunteer.DirtyData
{
    using System;
    using System.Collections.Generic;
    using TempDAL;
    using Volunteer.BLModels.Entities;

    public class UserData
    {
        public static Guid UserUid1 = new Guid("e281797e-1425-4b21-8650-3407d01cea00");
        public static Guid UserUid2 = new Guid("4db193ce-c7c4-4674-99c8-9c2e9bd5ee9a");

        static UserData()
        {
            var tempUserStore = new List<User>();
            tempUserStore.Add(new User
            {
                Uid = UserUid1,
                Login = "Max",
                FullName = "Карабаев Максим Олегович",
                PasswordHash = "123456",
                About = "Это Карабаев Максим Олегович - программист RDDS",
                AvatarUrl = "https://avatars.mds.yandex.net/get-pdb/28866/bc1b684a-8405-4c23-b76a-25648d529c52/s1200"
            });
            tempUserStore.Add(new User
            {
                Uid = UserUid2,
                Login = "Ild",
                FullName = "Вазетдинов Ильдар Радулевич",
                PasswordHash = "123456",
                About = "Это Ильдар - воображаемый друг",
                AvatarUrl = "https://avatars.mds.yandex.net/get-pdb/480866/719d9723-eac6-40c8-aab3-3c71a0b25a1e/s1200"
            });
            UserDataManager.tempStore = tempUserStore;
        }

        public static void InitializeTempData()
        {

        }
    }
}
