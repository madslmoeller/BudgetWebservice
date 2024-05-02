using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BudgetMVVM.Annotations;
using BudgetMVVM.Handler;
using BudgetMVVM.Model;

namespace BudgetMVVM.ViewModel
{
    class LineItemViewModel : INotifyPropertyChanged
    {
        // Mads

        public LineItemSingleton LineItemSingleton { get; set; }
        private LineItem newLineItem;
        private LineItem selectedLineItem;
        private LineItemHandler lineitemHandler;

        public ICommand CreateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public LineItem NewLineItem
        {
            get { return newLineItem; }
            set { newLineItem = value; OnPropertyChanged(); }
        }

        public LineItem SelectedLineItem
        {
            get { return selectedLineItem; }
            set { selectedLineItem = value; OnPropertyChanged(); }
        }



        public LineItemViewModel()
        {
            LineItemSingleton = LineItemSingleton.Instance;
            lineitemHandler = new Handler.LineItemHandler(this);

            newLineItem = new LineItem();

            CreateCommand = new RelayCommand(lineitemHandler.CreateLineItem);
            DeleteCommand = new RelayCommand(lineitemHandler.DeleteLineItem);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
