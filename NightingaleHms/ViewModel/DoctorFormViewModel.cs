using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using NightingaleHms.Models;

namespace NightingaleHms.ViewModel
{
    public class DoctorFormViewModel
    { 
        public IEnumerable<Department> Departments { get; set; }
        public IEnumerable<Plan> Plans { get; set; }
        public IEnumerable<State> States { get; set; }
        public IEnumerable<Education> Educations { get; set; }

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
        [Range(1, 100)]
        public byte? YearOfExperience { get; set; }

        //Doctor (one-to-zero/one) Department Relation
        [Display(Name = "Department")]
        public int? DepartmentId { get; set; }

        // Doctor (one-to-zero/one) Plan Relation
        [Display(Name = "Plan")]
        public int? PlanId { get; set; }

        // Doctor (one-to-zero/one) State Relation
        [Display(Name = "State")]
        public int? StateId { get; set; }

        public string Title
        {
            get
            {
                if (DoctorId == 0)
                    return "Add";

                return "Edit";
            }
        }

        public DoctorFormViewModel()
        {
            DoctorId = 0;
        }

        public DoctorFormViewModel(Doctor doctor)
        {
            DoctorId = doctor.DoctorId;
            FirstName = doctor.FirstName;
            LastName = doctor.LastName;
            YearOfExperience = doctor.YearOfExperience;
            DepartmentId = doctor.DepartmentId;
            PlanId = doctor.PlanId;
            StateId = doctor.StateId;
        }
    }
}