namespace Volunteer.DirtyData
{
    using DobrfDownloadModule;
    using System;
    using System.Collections.Generic;
    using TempDAL;
    using Volunteer.BLModels.Entities;

    public static class DobrfData
    {
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

            UserDataManager.tempStore.AddRange(tempUserStore);
        }

        public static void InitializeTempData()
        {

        }
    }
}
