
namespace Volunteer.Comments.Entity
{
    using System;
    using System.Collections.Generic;
    using BLModels.Interfaces;
    using Volunteer.BLModels.Entities;

    public class Comment : IEntity, IEvaluated
    {
        public Guid Uid { get; set; }
        public string Text { get; set; }
        public Guid AuthorUid { get; set; }
        public Guid EntityUid { get; set; }
        public Type EntityType { get; set; }
        public DateTime AddDateTime { get; set; }
        public IEnumerable<Mark> Marks { get; set; }
    }
}
