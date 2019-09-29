namespace Volunteer.DirtyData
{
    public static class TempDataInitializer
    {
        public static void Initialize()
        {
            ActivitiesData.InitializeTempData();
            //UserData.InitializeTempData();
            MarkData.InitializeTempData();
            ActivitiesUsersData.InitializeTempData();
            TagsData.InitializeTempData();
            DobrfData.InitializeTempData();
            FundData.InitializeTempData();
            CashFlowData.InitializeTempData();
        }
    }
}
