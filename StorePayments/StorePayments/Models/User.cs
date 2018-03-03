using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace StorePayments.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required, Display(Name = "User Name"), MinLength(5, ErrorMessage = "Minimum 5 Characters Required"), MaxLength(50, ErrorMessage = "Cannot Exceed 50 Characters")]
        public string UserName { get; set; }
        public string EmailId { get; set; }
    }
}