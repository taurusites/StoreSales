using System;
using System.ComponentModel.DataAnnotations;

namespace StoreSales.Models
{
    public class MonthlySales
    {
        public string Location { get; set; }
        [DataType(DataType.Currency)]
        public Nullable<decimal> TotalAsOnDate { get; set; }
        [DataType(DataType.Currency)]
        public Nullable<decimal> TotalSalesThisYear { get; set; }
        [DataType(DataType.Currency)]
        public Nullable<decimal> TotalSalesThisMonthLastYearTillDate { get; set; }
        [DataType(DataType.Currency)]
        public Nullable<decimal> TotalSalesThisMonth { get; set; }
        [DataType(DataType.Currency)]
        public Nullable<decimal> SalesThisMonthLastYear { get; set; }
        [DataType(DataType.Currency)]
        public Nullable<decimal> TotalSalesLastYearTillDate { get; set; }
        [DataType(DataType.Currency)]
        public Nullable<decimal> SalesLastYearNextMonth { get; set; }
    }
}