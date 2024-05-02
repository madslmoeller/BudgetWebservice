using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetMVVM.Model
{
    class LineItem
    {
        // Mads

        public int Id { get; set; }
        public int SubCatId { get; set; }
        public int Amount { get; set; }
        public int Year { get; set; }

        public LineItem(int id, int subCatId, int amount, int year)
        {
            Id = id;
            SubCatId = subCatId;
            Amount = amount;
            Year = year;
        }

        public LineItem()
        {
        }

        public override string ToString()
        {
            return $"Year: {Year}, Amount: {Amount}, Id: {Id}, SubCatId: {SubCatId}";
        }
    }
}
