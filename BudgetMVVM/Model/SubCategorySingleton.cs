using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetMVVM.Model
{
    class SubCategorySingleton
    {
        // Nikolai

        private static SubCategorySingleton instance = new SubCategorySingleton();

        public static SubCategorySingleton Instance
        {
            get { return instance; }
        }

        public ObservableCollection<SubCategory> SubCategory { get; set; }

        private SubCategorySingleton()
        {
            SubCategory = new ObservableCollection<SubCategory>(new PersistenceFacade().GetSubCategory());
        }
    }
}
