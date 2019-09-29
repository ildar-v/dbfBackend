namespace Volunteer.DirtyData
{
    using System;
    using System.Collections.Generic;
    using TempDAL;
    using TempDAL.FinanceSystemDAL;
    using Volunteer.Finances.Models;

    public class CashFlowData
    {
        public static Guid uid1 = new Guid("b32fca79-09d0-4f51-af3d-5a31f09288ae");
        public static Guid uid2 = new Guid("7e92b30c-2612-4437-b602-10b6016673a3");

        static CashFlowData()
        {
            var tempStore = new List<CashFlow>();
            tempStore.Add(new CashFlow
            {
                Uid = uid1,
                Amount = 100,
                Fund = new Fund
                {
                    Uid = new Guid("75e5f291-357f-46e6-abc7-b1dd8464e662"),
                    Title = "Стартовый",
                    Description = "Стартовый фонд",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now
                }
            });
            tempStore.Add(new CashFlow
            {
                Uid = uid2,
                Amount = 200,
                Fund = new Fund
                {
                    Uid = new Guid("d2ce081d-4216-46d5-bd60-b5b39db2322d"),
                    Title = "Продолжительный",
                    Description = "Продолжительный фонд",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now
                }
            });

            CashFlowDataManager.tempStore = tempStore;
        }

        public static void InitializeTempData()
        {

        }
    }
}
