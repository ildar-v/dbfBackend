namespace Volunteer.DirtyData
{
    using DobrfDownloadModule;
    using System;
    using System.Collections.Generic;
    using TempDAL;
    using Volunteer.BLModels.Entities;

    public static class DobrfData
    {
        public static Guid UserUid1 = new Guid("e281797e-1425-4b21-8650-3407d01cea00");
        public static Guid UserUid2 = new Guid("4db193ce-c7c4-4674-99c8-9c2e9bd5ee9a");

        static DobrfData()
        {
            DobrfDownloader dobrfDownloader = new DobrfDownloader();
            var volonteers = dobrfDownloader.GetVolunteers();
            var tempUserStore = new List<User>();

            foreach (var item in volonteers.results)
            {
                tempUserStore.Add(new User
                {
                    FullName = item.username,
                    About = item.bio,
                    Login = item.username,
                    AvatarUrl = item.photo.original,
                    Uid = Guid.NewGuid(),
                    PasswordHash = "123456"
                });
            }

            tempUserStore[0].Uid = UserUid1;
            tempUserStore[1].Uid = UserUid2;
            UserDataManager.tempStore = tempUserStore;
        }

        public static void InitializeTempData()
        {

        }
    }
}
