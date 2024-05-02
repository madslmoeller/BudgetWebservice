namespace BudgetWebservice
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LineItem")]
    public partial class LineItem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int SubCatId { get; set; }

        public int Amount { get; set; }

        public int Year { get; set; }

        public virtual SubCategory SubCategory { get; set; }
    }
}
