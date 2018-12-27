using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NightingaleHms.Models
{
    public class Plan
    {
        [Key]
        public int PlanId { get; set; }

        [StringLength(255)]
        [Required]
        public string Name { get; set; }
    }
}