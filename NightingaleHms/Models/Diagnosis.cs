using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NightingaleHms.Models
{
        public class Diagnosis
        {
            [Key]
            public int DiagnosisId { get; set; }

            [Required]
            public string Symptoms { get; set; }

            [Required]
            public string DiagnosisProvided { get; set; }

            [Required]
            public DateTime DateOfDiagnosis { get; set; }

            [Required]
            public bool IsFollowUpRequired { get; set; }

            [FollowUpDateIfFollowUpRequired]
            public DateTime? DateOfFollowUp { get; set; }

            //Navigation Properties.(Foreign Key).
            [Required]
            public int PatientId { get; set; }

            [ForeignKey("PatientId")]
            public Patient Patient { get; set; }

            //Diagnosis (Many-to-One) Doctor Relationship
            [Required]
            public int DoctorId { get; set; }

            [ForeignKey("DoctorId")]
            public Doctor Doctor { get; set; }

            //Diagnosis(one-to-One) Bill Relationship. Principle Table : Diagnosis , Dependent Table: Bill.
             public Bill Bill { get; set; }
        }
}