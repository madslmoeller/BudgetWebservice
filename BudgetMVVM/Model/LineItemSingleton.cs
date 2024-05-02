using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetMVVM.Model
{
    class LineItemSingleton
    {
        // Mads

        private static LineItemSingleton instance = new LineItemSingleton();

        public static LineItemSingleton Instance
        {
            get { return instance; }
        }

        public ObservableCollection<LineItem> LineItems { get; set; }

        private LineItemSingleton()
        {
            LineItems = new ObservableCollection<LineItem>(new PersistenceFacade().GetLineItems());

        }
    }
}
