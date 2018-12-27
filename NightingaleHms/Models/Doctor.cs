using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Web;

namespace NightingaleHms.Models
{
    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; }

        [Display(Name = "First Name")]
        [StringLength(25)]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [StringLength(25)]
        [Required]
        public string LastName { get; set; }

        [Display(Name = "Year of Experience")]
        [Range(1,100)]
        public byte? YearOfExperience { get; set; }

        //Doctor (one-to-zero/one) Department Relation
        [Display(Name = "Department")]
        public int? DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }

        // Doctor (one-to-zero/one) Plan Relation
        [Display(Name = "Plan")]
        public int? PlanId { get; set; }

        [ForeignKey("PlanId")]
        public Plan Plan { get; set; }

        // Doctor (one-to-zero/one) State Relation
        [Display(Name = "State")]
        public int? StateId { get; set; }

        [ForeignKey("StateId")]
        public State State { get; set; }

        //Doctor (one-to-zero/many) Education Relationship
        public IList<Education> Educations { get; set; }

        //Doctor (one-to-zero/many) Diagnosis Relationship
        public IList<Diagnosis> Diagnoses { get; set; }//Diagnoses is the plural form of Diagnosis

    }
}