using System.Collections.Generic;
using TempDAL;
using Volunteer.Tags.Models;

namespace Volunteer.DirtyData
{
    public class TagsData
    {
        public TagsData()
        {
            TagsDataManager.tempStore = new List<Tag>
            {
                new Tag
                {
                    Name = "Помощь пожилым",
                    EntityUids = new List<System.Guid>
                    {
                        ActivitiesData.ActivityUid1,
                        ActivitiesData.ActivityUid2
                    }
                },
                new Tag
                {
                    Name = "Молодежь",
                    EntityUids = new List<System.Guid>
                    {
                        ActivitiesData.ActivityUid2,
                        ActivitiesData.ActivityUid3
                    }
                },
                new Tag
                {
                    Name = "Образовние",
                    EntityUids = new List<System.Guid>
                    {
                        ActivitiesData.ActivityUid3,
                    }
                }
            };
        }
    }
}