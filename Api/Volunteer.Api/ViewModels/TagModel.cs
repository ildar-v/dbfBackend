using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Volunteer.Api.ViewModels
{
    public class TagModel
    {
        [Required]
        public Guid EntityUid { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
