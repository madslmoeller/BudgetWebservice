using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetMVVM.Model;
using BudgetMVVM.ViewModel;

namespace BudgetMVVM.Handler
{
    class LineItemHandler
    {
        // Mads

        public LineItemViewModel LineItemViewModel { get; set; }

        public LineItemHandler(LineItemViewModel lineItemViewModel)
        {
            LineItemViewModel = lineItemViewModel;
        }

        public void CreateLineItem()
        {
            LineItem newLineItem = LineItemViewModel.NewLineItem;
            var isSaved = new PersistenceFacade().SaveLineItem(newLineItem);

            if (isSaved)
            {
                LineItemViewModel.LineItemSingleton.LineItems.Add(newLineItem);
            }
        }

        public void DeleteLineItem()
        {
            LineItem selectedLineItem = LineItemViewModel.SelectedLineItem;
            var isDeleted = new PersistenceFacade().DeleteLineItem(selectedLineItem);

            if (isDeleted)
            {
                LineItemViewModel.LineItemSingleton.LineItems.Remove(selectedLineItem);
            }
        }
    }
}
