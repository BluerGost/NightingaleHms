using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NightingaleHms.Models
{
    public class BloodType
    {
        [Key]
        public byte BloodTypeId { get; set; }

        [StringLength(3)]
        [Required]
        public string Name { get; set; }
    }
}