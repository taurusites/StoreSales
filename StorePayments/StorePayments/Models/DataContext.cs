using System;
using System.Data.Entity;

namespace StorePayments.Models
{
    public class DataContext : DbContext
    {
        public DataContext() : base("name=DefaultConnection") { }
    }
}