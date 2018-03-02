using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StorePayments.Models
{
    public class Store
    {
        [Key]
        public int StoreId { get; set; }
        [Required,Display(Name ="Store Name"),MinLength(5,ErrorMessage ="Minimum 5 Characters Required"),MaxLength(50,ErrorMessage ="Cannot Exceed 50 Characters")]
        public string StoreName { get; set; }
    }
}