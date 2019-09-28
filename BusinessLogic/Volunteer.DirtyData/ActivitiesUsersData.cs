namespace Volunteer.DirtyData
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using TempDAL;
    using Volunteer.BLModels.Entities;

    public static class ActivitiesUsersData
    {
        static ActivitiesUsersData()
        {
            var tempData = new List<ActivitiesUsers>()
            {
                new ActivitiesUsers
                {
                    Uid = Guid.NewGuid(),
                    ActivityGuid = ActivitiesData.ActivityUid1,
                    UserGuid = UserData.UserUid1,
                    UserType = BLModels.Enums.UserTypes.Organizer
                },
                new ActivitiesUsers
                {
                    Uid = Guid.NewGuid(),
                    ActivityGuid = ActivitiesData.ActivityUid1,
                    UserGuid = UserData.UserUid2,
                    UserType = BLModels.Enums.UserTypes.Organizer
                },
                new ActivitiesUsers
                {
                    Uid = Guid.NewGuid(),
                    ActivityGuid = ActivitiesData.ActivityUid2,
                    UserGuid = UserData.UserUid1,
                    UserType = BLModels.Enums.UserTypes.Organizer
                },
                new ActivitiesUsers
                {
                    Uid = Guid.NewGuid(),
                    ActivityGuid = ActivitiesData.ActivityUid2,
                    UserGuid = UserData.UserUid2,
                    UserType = BLModels.Enums.UserTypes.Volunteer
                },
                new ActivitiesUsers
                {
                    Uid = Guid.NewGuid(),
                    ActivityGuid = ActivitiesData.ActivityUid3,
                    UserGuid = UserData.UserUid2,
                    UserType = BLModels.Enums.UserTypes.Organizer
                },
            };

            ActivitiesUsersDataManager.tempStore = tempData;
        }

        public static void InitializeTempData()
        {

        }
    }
}
