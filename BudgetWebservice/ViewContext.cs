namespace BudgetWebservice
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ViewContext : DbContext
    {
        public ViewContext()
            : base("name=ViewContext")
        {
            base.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<AccountsCurrentYear> AccountsCurrentYears { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountsCurrentYear>()
                .Property(e => e.Subcategory)
                .IsUnicode(false);

            modelBuilder.Entity<AccountsCurrentYear>()
                .Property(e => e.Procent)
                .HasPrecision(12, 2);
        }
    }
}
