namespace Volunteer.DirtyData
{
    using System;
    using System.Collections.Generic;
    using TempDAL;
    using TempDAL.FinanceSystemDAL;
    using Volunteer.Finances.Models;

    public class FundData
    {
        public static Guid uid1 = new Guid("75e5f291-357f-46e6-abc7-b1dd8464e662");
        public static Guid uid2 = new Guid("d2ce081d-4216-46d5-bd60-b5b39db2322d");

        static FundData()
        {
            var tempStore = new List<Fund>();
            tempStore.Add(new Fund
            {
                Uid = uid1,
                Title = "Стартовый",
                Description = "Стартовый фонд",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now
            });
            tempStore.Add(new Fund
            {
                Uid = uid2,
                Title = "Продолжительный",
                Description = "Продолжительный фонд",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now
            });

            FundDataManager.tempStore = tempStore;
        }

        public static void InitializeTempData()
        {

        }
    }
}
