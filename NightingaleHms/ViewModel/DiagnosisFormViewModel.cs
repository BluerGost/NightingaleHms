using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using NightingaleHms.Models;

namespace NightingaleHms.ViewModel
{
    public class DiagnosisFormViewModel
    {
        public IEnumerable<Patient> Patients { get; set; }
        public IEnumerable<Doctor> Doctors { get; set; }
        public IEnumerable<Bill> Bills { get; set; }

        [Key]
        public int? DiagnosisId { get; set; }

        [Required]
        public string Symptoms { get; set; }

        [Display(Name = "Diagnosis Provided")]
        [Required]
        public string DiagnosisProvided { get; set; }

        [Display(Name = "Date Of Diagnosis")]
        [Required]
        public DateTime? DateOfDiagnosis { get; set; }

        [Required]
        public bool IsFollowUpRequired { get; set; }

        [Display(Name = "Date Of FollowUp")]
        [FollowUpDateIfFollowUpRequired]
        public DateTime? DateOfFollowUp { get; set; }

        //Navigation Properties.(Foreign Key).
        [Display(Name = "Patient")]
        [Required]
        public int? PatientId { get; set; }


        //Diagnosis (Many-to-One) Doctor Relationship
        [Display(Name = "Doctor")]
        [Required]
        public int? DoctorId { get; set; }

        [Required]
        public int? BillId { get; set; }

        public DiagnosisFormViewModel()
        {
            //new Diagnosis creation form gets 0 as diagnosis Id.
            DiagnosisId = 0;
            IsFollowUpRequired = false;
        }

        public DiagnosisFormViewModel(Diagnosis diagnosis)
        {
            DiagnosisId = diagnosis.DiagnosisId;
            Symptoms = diagnosis.Symptoms;
            DiagnosisProvided = diagnosis.DiagnosisProvided;
            DateOfDiagnosis = diagnosis.DateOfDiagnosis;
            IsFollowUpRequired = diagnosis.IsFollowUpRequired;
            DateOfFollowUp = diagnosis.DateOfFollowUp;
            //Navigation Property(FK)
            PatientId = diagnosis.PatientId;
            DoctorId = diagnosis.DoctorId;
            //BillId = diagnosis.Bill;

        }
    }
}