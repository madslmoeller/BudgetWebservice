using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BudgetManager.Model;
using BudgetMVVM.Handler;
using BudgetMVVM.Model;

namespace BudgetMVVM.ViewModel
{
    class InvoiceViewModel : INotifyPropertyChanged
    {
        // Jon

        public InvoiceSingleton InvoiceSingleton { get; set; }
        private Invoice newInvoice;
        private Invoice selectedInvoice;
        private InvoiceHandler invoiceHandler;

        public ICommand CreateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public Invoice NewInvoice
        {
            get { return newInvoice;}
            set { newInvoice = value; OnPropertyChanged(); }
        }

        public Invoice SelectedInvoice
        {
            get { return selectedInvoice;}
            set { selectedInvoice = value; OnPropertyChanged(); }
        }

        public InvoiceViewModel()
        {
            InvoiceSingleton = InvoiceSingleton.Instance;
            invoiceHandler = new Handler.InvoiceHandler(this);

            newInvoice = new Invoice();

            CreateCommand = new RelayCommand(invoiceHandler.CreateInvoice);
            DeleteCommand = new RelayCommand(invoiceHandler.DeleteInvoice);
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
