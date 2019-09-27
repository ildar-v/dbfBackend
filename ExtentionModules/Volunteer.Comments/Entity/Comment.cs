
namespace Volunteer.Comments.Entity
{
    using System;
    using BLModels.Interfaces;

    public class Comment : IEntity, IRatingable
    {
        public Guid Uid { get; set; }
        public string Text { get; set; }
        public Guid AuthorUid { get; set; }
        public Guid EntityUid { get; set; }
        public Type EntityType { get; set; }
        public IRating Rating { get; set; }
        public Comment Parent { get; set; }
        public DateTime AddDateTime { get; set; }
    }
}
