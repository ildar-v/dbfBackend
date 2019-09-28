namespace Volunteer.DirtyData
{
    using System;
    using System.Collections.Generic;
    using TempDAL;
    using Volunteer.BLModels.Entities;
    using Volunteer.Comments.DataManager;
    using Volunteer.Comments.Entity;

    public static class ActivitiesData
    {
        private static Guid ActivityUid1 = new Guid("75d60dd6-48bd-454c-b2d2-ecd959d7d90a");
        private static Guid ActivityUid2 = new Guid("11248ba9-953e-4605-ba8e-9ee0fa1a4c65");
        private static Guid ActivityUid3 = new Guid("c84f66e7-eab8-4429-bbb7-9ac4250403d5");

        static ActivitiesData()
        {
            ActivityDataManager.tempStore = tempActivityStore;

            var tempActivityCommentStore = new List<Comment> {
            new Comment
            {
                Uid = Guid.NewGuid(),
                Text = "Тестовый коммент1 у активити",
                AddDateTime = DateTime.Now,
                AuthorUid = Guid.Empty,
                Parent = null,
                EntityType = typeof(Activity),
                EntityUid = ActivityUid2
            },
            new Comment
            {
                Uid = Guid.NewGuid(),
                Text = "Тестовый коммент2 у активити",
                AddDateTime = DateTime.Now,
                AuthorUid = Guid.Empty,
                Parent = null,
                EntityType = typeof(Activity),
                EntityUid = ActivityUid2
            }
            };
            var comment3 = new Comment
            {
                Uid = Guid.NewGuid(),
                Text = "Тестовый коммент3 у активити",
                AddDateTime = DateTime.Now,
                AuthorUid = Guid.Empty,
                Parent = null,
                EntityType = typeof(Activity),
                EntityUid = ActivityUid3
            };
            var comment4 = new Comment
            {
                Uid = Guid.NewGuid(),
                Text = "Тестовый коммент4 у активити",
                AddDateTime = DateTime.Now,
                AuthorUid = Guid.Empty,
                Parent = comment3,
                EntityType = typeof(Activity),
                EntityUid = ActivityUid3
            };
            tempActivityCommentStore.Add(comment3);
            tempActivityCommentStore.Add(comment4);
            CommentDataManager.tempStore = tempActivityCommentStore;
        }

        private static List<Activity> tempActivityStore = new List<Activity>()
        {
            new Activity()
            {
                Uid = ActivityUid1,
                Description = "Какое-то описание",
                Title = "Какое-то название",
                AddDateTime = DateTime.Now
            },
            new Activity()
            {
                Uid = ActivityUid2,
                Description = "Какое-то описание-1",
                Title = "Какое-то название-1",
                AddDateTime = DateTime.Now
            },
            new Activity()
            {
                Uid = ActivityUid3,
                Description = "Какое-то описание-2",
                Title = "Какое-то название-2",
                AddDateTime = DateTime.Now
            }
        };

        public static void InitializeTempData()
        {

        }
    }
}
