using System;
using System.Data.Entity;

namespace StorePayments.Models
{
    public class DbDataContext : DbContext
    {
        public DbDataContext() : base("name=DefaultConnection") { }

        public DbSet<StateNames> StateNames { get; set; }
        public DbSet<AddressTable> AddressesTable { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<User> Users { get; set; }
    }
}