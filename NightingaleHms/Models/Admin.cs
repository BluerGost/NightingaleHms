using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NightingaleHms.Models
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }

        [Display(Name = "First Name")]
        [StringLength(25)]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [StringLength(25)]
        [Required]
        public string LastName { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [StringLength(30)]
        [Required]
        public string Password { get; set; }     
    }
}