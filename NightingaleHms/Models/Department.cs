using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NightingaleHms.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        [StringLength(255)]
        [Required]
        public string Name { get; set; }

        //not required
        public string Description { get; set; }
    }
}