using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using NightingaleHms.Models;

namespace NightingaleHms.ViewModel
{
    public class PatientFormViewModel
    {
        public IEnumerable<State> States { get; set; }
        public IEnumerable<Plan> Plans { get; set; }
        public IEnumerable<BloodType> BloodTypes { get; set; }
        public IEnumerable<Sex> Sexes { get; set; }


        [Key]
        public int? PatientId { get; set; }

        [Display(Name = "First Name")]
        [StringLength(25)]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [StringLength(25)]
        [Required]
        public string LastName { get; set; }

        [Required]
        public int? Phone { get; set; }

        [Range(0, 200)]
        [Required]
        public int? Age { get; set; }

        [EmailAddress]
        [StringLength(300)]
        public string Email { get; set; }

        //Sex
        [Display(Name = "Sex")]
        [Required]
        public byte? SexId { get; set; }

        //Blood Type
        [Display(Name = "Blood Type")]
        public byte? BloodTypeId { get; set; }

        //State
        [Display(Name = "State")]
        public int? StateId { get; set; }

        //Plan
        [Display(Name = "Plan")]
        public int? PlanId { get; set; }

        public string Title
        {
            get
            {
                if (PatientId == 0)
                    return "Add";

                return "Edit";
            }
        }

        public PatientFormViewModel()
        {
            PatientId = 0;//new user
        }
        public PatientFormViewModel(Patient patient)
        {
            PatientId = patient.PatientId;
            FirstName = patient.FirstName;
            LastName = patient.LastName;
            Phone = patient.Phone;
            Age = patient.Age;
            Email = patient.Email;
            SexId = patient.SexId;
            BloodTypeId = patient.BloodTypeId;
            StateId = patient.StateId;
            PlanId = patient.PlanId;
        }
    }
}