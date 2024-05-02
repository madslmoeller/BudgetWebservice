namespace BudgetWebservice
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AccountsCurrentYear")]
    public partial class AccountsCurrentYear
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(100)]
        public string Subcategory { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Budget { get; set; }

        public int? Total { get; set; }

        public int? Difference { get; set; }

        public decimal? Procent { get; set; }
    }
}
