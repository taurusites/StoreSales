using System;
using System.Data.Entity;

namespace StoreSales.Models
{
    public partial class FusionDbContext : DbContext
    {
        public FusionDbContext() : base("name=DefaultConnection") { }
    }
}