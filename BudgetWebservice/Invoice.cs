namespace BudgetWebservice
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Invoice")]
    public partial class Invoice
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int SubCatId { get; set; }

        [Required]
        [StringLength(100)]
        public string InvoiceNo { get; set; }

        [Required]
        [StringLength(100)]
        public string SupplierName { get; set; }

        public int Amount { get; set; }

        public int Year { get; set; }

        public virtual SubCategory SubCategory { get; set; }
    }
}
