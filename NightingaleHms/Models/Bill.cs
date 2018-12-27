using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace NightingaleHms.Models
{
    public class Bill
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        [ForeignKey("Diagnosis")]
        public int BillId { get; set; }

        [Required]
        public double Amount { get; set; }

        [Required]
        public bool IsCardPayment { get; set; }//true=card payment (take card number), false=other type of payment(dont take card number).

        [Display(Name = "Card Number")]
        [CardNumberIfIsCardPayment]
        [StringLength(19)]
        public string CardNumber { get; set; }


        //Navigation Property.

        //Bill (One-to-One) Diagnosis Relationship.}
        //This is required to make BIllId PK and FK which makes it one to one relationship between this 2 table.

        public Diagnosis Diagnosis { get; set; }
    }
}
