using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Volunteer.Api.Models
{
    public class CommentModel
    {
        [Required]
        public Guid EntityUid { get; set; }
        [Required]
        public Guid AuthorUid { get; set; }
        [Required]
        public string Text { get; set; }
    }
}
