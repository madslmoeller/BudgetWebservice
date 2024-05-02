using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BudgetManager.Model
{
    [JsonObject(MemberSerialization.OptOut)]
    class Invoice
    {
        // Jon

        public int Id { get; set; }
        public int SubCatId { get; set; }
        public string InvoiceNo { get; set; }
        public string SupplierName { get; set; }
        public int Amount { get; set; }
        public int Year { get; set; } = DateTime.Today.Year;

        public Invoice() { }

        public Invoice(int id, int subCatId, string invoiceNo, string supplierName, int amount)
        {
            Id = id;
            SubCatId = subCatId;
            InvoiceNo = invoiceNo;
            SupplierName = supplierName;
            Amount = amount;
        }

        //public Invoice(string invoiceNo, string supplierName, int amount)
        //{
        //    InvoiceNo = invoiceNo;
        //    SupplierName = supplierName;
        //    Amount = amount;
        //    SubCatId = 1; //todo
        //    Year = DateTime.Today.Year; //todo
        //}

        public override string ToString()
        {
            return $"{Id} {nameof(SubCatId)}: {SubCatId}, {nameof(InvoiceNo)}: {InvoiceNo}, {nameof(SupplierName)}: {SupplierName}, {nameof(Amount)}: {Amount}, {nameof(Year)}: {Year}";
        }
    }
}
