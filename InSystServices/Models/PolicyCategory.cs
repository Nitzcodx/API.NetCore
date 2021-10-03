using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace InSystServices.Models
{
    public class PolicyCategory
    {
        [Required]
        public string PolicyType { get; set; }
        [MaxLength(2)]
        public string PolicyCategoryId { get; set; }
        [Required]
        public string PolicyCategoryName { get; set; }
        [DataType(DataType.MultilineText)]
        [Required]
        public string Description { get; set; }
        [Required]
        public bool? IsActive { get; set; }
    }
}
