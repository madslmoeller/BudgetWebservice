using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using BudgetMVVM.Model;
using BudgetMVVM.ViewModel;

namespace BudgetMVVM.Handler
{
    class MainCatagoryHandler
    {
        // Bipin

        public MainCatagoryViewModel CatViewModel { get; set; }

        public MainCatagoryHandler(MainCatagoryViewModel catviewmodel)
        {
            CatViewModel = catviewmodel;
        }

        public async void preparecategory()

        {
            if (string.IsNullOrWhiteSpace(CatViewModel.NewCatagory.Name) || 0 >= CatViewModel.NewCatagory.Id)
            {
                var mesg = new MessageDialog("Please Input Valid Data", "Notification:");
                await mesg.ShowAsync();

            }
            else
            {
                CatViewModel.singleton.CreateCatagory(CatViewModel.NewCatagory);

            }

        }

        public void delCatagory()
        {
            CatViewModel.singleton.DeleteCatagory(CatViewModel.SelectedCatagory);
        }
    }
}
