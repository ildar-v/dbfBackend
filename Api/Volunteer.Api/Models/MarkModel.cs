using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Volunteer.Api.Models
{
    public class MarkModel
    {
        [Required]
        public string EntityUid { get; set; }
        [Required]
        public string UserUid { get; set; }
    }
}
