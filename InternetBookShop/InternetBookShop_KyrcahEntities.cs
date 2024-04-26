using System;

namespace InternetBookShop
{
    using InternetBookShop;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    public partial class Entitis : DbContext
    {

        public Entitis()
            : base("name=InternetBookShop_KyrcahEntities") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new System.NotImplementedException();
        }
        public virtual DbSet<InternetBookShop_KyrcahEntities> InternetBookShop_KyrcahEntities { get; set; }
    }
}