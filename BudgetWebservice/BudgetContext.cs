namespace BudgetWebservice
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BudgetContext : DbContext
    {
        public BudgetContext()
            : base("name=BudgetContext")
        {
            base.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<LineItem> LineItems { get; set; }
        public virtual DbSet<MainCategory> MainCategories { get; set; }
        public virtual DbSet<SubCategory> SubCategories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Invoice>()
                .Property(e => e.InvoiceNo)
                .IsUnicode(false);

            modelBuilder.Entity<Invoice>()
                .Property(e => e.SupplierName)
                .IsUnicode(false);

            modelBuilder.Entity<MainCategory>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<MainCategory>()
                .HasMany(e => e.SubCategories)
                .WithRequired(e => e.MainCategory)
                .HasForeignKey(e => e.MainCatId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SubCategory>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<SubCategory>()
                .HasMany(e => e.Invoices)
                .WithRequired(e => e.SubCategory)
                .HasForeignKey(e => e.SubCatId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SubCategory>()
                .HasMany(e => e.LineItems)
                .WithRequired(e => e.SubCategory)
                .HasForeignKey(e => e.SubCatId)
                .WillCascadeOnDelete(false);
        }

        public System.Data.Entity.DbSet<BudgetWebservice.AccountsCurrentYear> AccountsCurrentYears { get; set; }
    }
}
