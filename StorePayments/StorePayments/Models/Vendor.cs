using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StorePayments.Models
{
    public class Vendor
    {
        [Key]
        public int VendorId { get; set; }
        [Required, Display(Name = "Vendor Name"), MinLength(5, ErrorMessage = "Minimum 5 Characters Required"), MaxLength(50, ErrorMessage = "Cannot Exceed 50 Characters")]
        public string VendorName { get; set; }
    }
}