using System;
using System.Data.Entity;

namespace StorePayments.Models
{
    public class DbDataContext : DbContext
    {
        public DbDataContext() : base("name=DefaultConnection") { }

        public System.Data.Entity.DbSet<StorePayments.Models.StateNames> StateNames { get; set; }
    }
}