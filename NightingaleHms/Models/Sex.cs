using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NightingaleHms.Models
{
    public class Sex
    {
        [Key]
        public byte SexId { get; set; }

        [StringLength(10)]
        [Required]
        public string Name { get; set; }
    }
}