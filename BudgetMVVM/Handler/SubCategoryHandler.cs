using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetMVVM.ViewModel;
using BudgetMVVM.Model;
using BudgetManager.Model;

namespace BudgetMVVM.Handler
{
    class SubCategoryHandler
    {
        // Nikolai

        private SubCategoryViewModel subCategoryViewModel;

        private SubCategory selectedSubCategory;

        public SubCategoryViewModel SubCategory { get; set; }

        public SubCategoryHandler(SubCategoryViewModel SubCategoryViewModel)
        {
            SubCategoryViewModel = SubCategoryViewModel;
        }

        //public void CreateSubCategory()
        //{
        //    Model.SubCategory newSubCategory = SubCategoryViewModel.NewSubCategory;
        //    var isSaved = new PersistenceFacade().SaveSubCategory(newSubCategory);

        //    if (isSaved)
        //    {
        //        SubCategoryViewModel.SubCategorySingleton.SubCategory.Add(newSubCategory);
        //    }
        //}

        //public void DeleteSubCategory()
        //{
        //    SubCategory selectedSubCategory = SubCategoryViewModel.SelectedSubCategory;
        //    var isDeleted = new PersistenceFacade().DeleteSubCategory(selectedSubCategory);

        //    if (isDeleted)
        //    {
        //        SubCategoryViewModel.SubCategorySingleton.SubCategory.Remove(this.selectedSubCategory);
        //    }
        //}
    }
}