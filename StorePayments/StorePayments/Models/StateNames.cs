using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StorePayments.Models
{
    public class StateNames
    {
        [Key]
        public int StateId { get; set; }
        [Required, Display(Name = "State Name"), MinLength(5, ErrorMessage = "Minimum 5 Characters Required"), MaxLength(50, ErrorMessage = "Cannot Exceed 50 Characters")]
        public string StateName { get; set; }
    }
}