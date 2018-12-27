using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NightingaleHms.Models
{
    //This table has many-to-many relation with Doctor table.
    public class Education
    {
        [Key]
        public int EducationId { get; set; }

        [StringLength(255)]
        [Required]
        public string SchoolName { get; set; }

        [StringLength(255)]
        public string DegreeName { get; set; }  

        [StringLength(25)]
        public string FieldOfStudy { get; set; }

        [Range(0.0,5.0)]
        public float? Grade { get; set; }

        public DateTime? PassingYear { get; set; }

        //Doctor (one-to-zero/many) Education Relationship  
        public int? DoctorId { get; set; }

        [ForeignKey("DoctorId")]
        public Doctor Doctor { get; set; }
    }
}