using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetManager.Model;
using BudgetMVVM.Model;
using BudgetMVVM.ViewModel;

namespace BudgetMVVM.Handler
{
    class InvoiceHandler
    {
        // Jon

        public InvoiceViewModel InvoiceViewModel { get; set; }

        public InvoiceHandler(InvoiceViewModel invoiceViewModel)
        {
            InvoiceViewModel = invoiceViewModel;
        }

        public void CreateInvoice()
        {
            bool isSaved = false;

            if (InvoiceSingleton.Instance.isUniqueInvoiceId(InvoiceViewModel.NewInvoice))
            {
                isSaved = new PersistenceFacade().SaveInvoice(InvoiceViewModel.NewInvoice);
            }
            if (isSaved)
            {
                InvoiceViewModel.InvoiceSingleton.Invoices.Add(InvoiceViewModel.NewInvoice);
            }
            else
            {
                //todo some messge
            }



            //Invoice newInvoice = InvoiceViewModel.NewInvoice;
            //var isSaved = new PersistenceFacade().SaveInvoice(newInvoice);

            //if (isSaved)
            //{
            //    InvoiceViewModel.InvoiceSingleton.Invoices.Add(newInvoice);
            //}
        }

        public void DeleteInvoice()
        {
            Invoice selectedInvoice = InvoiceViewModel.SelectedInvoice;
            var isDeleted = new PersistenceFacade().DeleteInvoice(selectedInvoice);

            if (isDeleted)
            {
                InvoiceViewModel.InvoiceSingleton.Invoices.Remove(selectedInvoice);
            }
            
        }
    }
}
