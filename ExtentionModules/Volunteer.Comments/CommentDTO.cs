using System;
using System.Collections.Generic;
using System.Text;
using Volunteer.DTO;

namespace Volunteer.Comments
{
    public class CommentDTO
    {
        public Guid Uid { get; set; }
        public string Text { get; set; }
        public Guid AuthorUid { get; set; }
        public UserDTO Author { get; set; }
        public Guid EntityUid { get; set; }
        public Type EntityType { get; set; }
        public DateTime AddDateTime { get; set; }
        public int Mark { get; set; }
    }
}
