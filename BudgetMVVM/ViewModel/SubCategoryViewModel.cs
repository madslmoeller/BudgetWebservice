using BudgetMVVM.Handler;
using BudgetMVVM.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BudgetMVVM.ViewModel
{

    class SubCategoryViewModel : INotifyPropertyChanged
    {
        // Nikolai

        public SubCategorySingleton SubCategorySingleton { get; set; }
        private SubCategory newSubCategory;
        private SubCategory selectedSubCategory;
        private SubCategoryHandler SubCategoryHandler;

        public ICommand CreateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public SubCategory NewSubCategory
        {
            get { return newSubCategory; }
            set { newSubCategory = value; OnPropertyChanged(); }
        }

        public SubCategory SelectedSubCategory

        {
            get { return selectedSubCategory; }
            set { selectedSubCategory = value; OnPropertyChanged(); }
        }

        //public static SubCategory NewSubCategory { get; internal set; }
        //public static SubCategory SelectedSubCategory { get; internal set; }

        public SubCategoryViewModel()
        {
            SubCategorySingleton = SubCategorySingleton.Instance;
            SubCategoryHandler = new Handler.SubCategoryHandler(this);

            newSubCategory = new SubCategory();

            //CreateCommand = new RelayCommand(SubCategoryHandler.CreateSubCategory);
            //DeleteCommand = new RelayCommand(SubCategoryHandler.DeleteSubCategory);
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}