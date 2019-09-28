namespace Volunteer.DirtyData
{
    using System.Collections.Generic;
    using TempDAL;
    using Volunteer.BLModels.Entities;

    public static class MarkData
    {
        static MarkData()
        {
            var tempMarkStore = new List<Mark>
            {
                new Mark
                {
                    EntityUid = ActivitiesData.ActivityUid1,
                    UserUid = UserData.UserUid1,
                    Flag = true
                },
                new Mark
                {
                    EntityUid = ActivitiesData.ActivityUid1,
                    UserUid = UserData.UserUid2,
                    Flag = true
                },
                new Mark
                {
                    EntityUid = ActivitiesData.ActivityUid2,
                    UserUid = UserData.UserUid1,
                    Flag = false
                }
            };
            MarkDataManager.tempStore = tempMarkStore;
        }

        public static void InitializeTempData()
        {

        }
    }
}
