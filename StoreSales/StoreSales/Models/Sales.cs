using System;
using System.ComponentModel.DataAnnotations;

namespace StoreSales.Models
{
    public class Sales
    {
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public DateTime RecModDate { get; set; }
        [Display(Name = "Transaction No")]
        public int tranno { get; set; }
        [Display(Name = "Register")]
        public string registerid { get; set; }
        [Display(Name = "Amount")]
        [DataType(DataType.Currency)]
        public decimal TenderAmount { get; set; }
        [Display(Name = "Credit Card / Check No")]
        public string ID1 { get; set; }
    }
}