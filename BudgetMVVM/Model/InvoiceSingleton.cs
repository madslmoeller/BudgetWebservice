using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetManager.Model;

namespace BudgetMVVM.Model
{
    class InvoiceSingleton
    {
        // Jon

        private static InvoiceSingleton instance = new InvoiceSingleton();

        public static InvoiceSingleton Instance
        {
            get { return instance; }
        }

        public ObservableCollection<Invoice> Invoices { get; set; }

        private InvoiceSingleton()
        {
            Invoices = new ObservableCollection<Invoice>(new PersistenceFacade().GetInvoices());
        }

        public bool isUniqueInvoiceId(Invoice i)
        {
            List<int> idList = new List<int>();

            foreach (var invoice in Invoices)
            {
                idList.Add(invoice.Id);
            }
            return !idList.Contains(i.Id);
        }
    }
}