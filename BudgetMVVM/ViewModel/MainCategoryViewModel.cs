using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;
using BudgetMVVM.Annotations;
using BudgetMVVM.Handler;
using BudgetMVVM.Model;

namespace BudgetMVVM.ViewModel
{
    class MainCatagoryViewModel : INotifyPropertyChanged
    {
        // Bipin

        public MainCatagorySingleton singleton { get; set; } //yo get set coz hamilai esma paxi listview bind garera obscollection dekhaunu xa.
        private MainCatagoryHandler handler;
        private MainCatagory _newCatagory;

        public MainCatagory NewCatagory
        {
            get { return _newCatagory; }
            set { _newCatagory = value; OnPropertyChanged(); }
        }
        public MainCatagory SelectedCatagory { get; set; }
        public ICommand CreateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public MainCatagoryViewModel()
        {
            singleton = MainCatagorySingleton.Instance;
            handler = new Handler.MainCatagoryHandler(this);
            _newCatagory = new MainCatagory();
            CreateCommand = new RelayCommand(handler.preparecategory);
            DeleteCommand = new RelayCommand(handler.delCatagory);

        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }


}
