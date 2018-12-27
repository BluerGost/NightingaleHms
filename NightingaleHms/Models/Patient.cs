using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NightingaleHms.Models
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }

        [Display(Name = "First Name")]
        [StringLength(25)]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [StringLength(25)]
        [Required]
        public string LastName { get; set; }

        [Required]
        public int Phone { get; set; }

        [Range(0, 200)]
        [Required]
        public int Age { get; set; }

        [EmailAddress]
        [StringLength(300)]
        public string Email { get; set; }

        //Sex
        [Display(Name = "Sex")]
        [Required]
        public byte SexId { get; set; }

        [ForeignKey("SexId")]
        public Sex Sex { get; set; }

        //Blood Type
        [Display(Name = "Blood Type")]
        public byte? BloodTypeId { get; set; }

        [ForeignKey("BloodTypeId")]
        public BloodType BloodType { get; set; }

        //State
        [Display(Name = "State")]
        public int? StateId { get; set; }

        [ForeignKey("StateId")]
        public State State { get; set; }

        //Plan
        [Display(Name = "Plan")]
        public int? PlanId { get; set; }

        [ForeignKey("PlanId")]
        public Plan Plan { get; set; }   
    }
}