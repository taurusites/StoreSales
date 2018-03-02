using System;
using System.Data.Entity;

namespace StoreSales.Models
{
    public class PADbContext : DbContext
    {
        public PADbContext() : base("name=PAConnection") { }
    }
}