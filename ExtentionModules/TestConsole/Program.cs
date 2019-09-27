namespace TestConsole
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Volunteer.MainModule.Managers.Implementations;
    using Volunteer.MainModule.Managers.Filters;
    using Volunteer.BLModels.Entities;
    using TempDAL;

    public class Program
    {
        static void Main(string[] args)
        {
            ActivityDataManager activityDataManager = new ActivityDataManager();
            ActivityManager activityManager = new ActivityManager(activityDataManager);
            var res1 = activityManager.Save(new Activity
            {
                Title = "Тест",
                Description = "Тестовое активити"
            });

            var res2 = activityManager.Save(new Activity
            {
                Title = "Не тест",
                Description = "Не тестовое активити"
            });

            var acivities = activityManager.Find(new Filter(new Dictionary<string, object[]>
            {
                {
                    "Title", new object[] { "Тест" }
                }
            })).ToList();

            var count = activityManager.Find().Count();

            foreach (var item in acivities)
            {
                Console.WriteLine(item.Description);
            }

            Console.ReadLine();
        }
    }
}
