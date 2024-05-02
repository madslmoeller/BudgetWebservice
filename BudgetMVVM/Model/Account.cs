using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetMVVM.Model
{
    class Account
    {
        // Jon

        public string Subcategory { get; set; }
        public int Budget { get; set; }
        public int? Total { get; set; }
        public int? Difference { get; set; }
        public decimal? Procent { get; set; }

        public Account(string subcategory, int budget, int total, int difference, decimal procent)
        {
            Subcategory = subcategory;
            Budget = budget;
            Total = total;
            Difference = difference;
            Procent = procent;
        }
        public override string ToString()
        {
            return $"{Subcategory}, {nameof(Budget)}: {Budget}, {nameof(Total)}: {Total}, {nameof(Difference)}: {Difference}, {nameof(Procent)}: {Procent}";
        }
    }
}
