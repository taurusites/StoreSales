using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace StorePayments.Models
{
    public class AddressTable
    {
        [Key]
        public int AddressId { get; set; }
        [Required, Display(Name = "Address Line 1"), MinLength(5, ErrorMessage = "Minimum 5 Characters Required"), MaxLength(50, ErrorMessage = "Cannot Exceed 50 Characters")]
        public string AddLine1 { get; set; }
        [Required, Display(Name = "Address Line 2"), MinLength(5, ErrorMessage = "Minimum 5 Characters Required"), MaxLength(50, ErrorMessage = "Cannot Exceed 50 Characters")]
        public string AddLine2 { get; set; }
        [Required, Display(Name = "State"), MinLength(5, ErrorMessage = "Minimum 5 Characters Required"), MaxLength(50, ErrorMessage = "Cannot Exceed 50 Characters")]
        public string StateName { get; set; }
        [Required, Display(Name = "Zip"), MinLength(5, ErrorMessage = "Minimum 5 Characters Required"), MaxLength(5, ErrorMessage = "Cannot Exceed 5 Characters")]
        public string Zip { get; set; }
        public virtual ICollection<StateNames> States { get; set; }
    }
}