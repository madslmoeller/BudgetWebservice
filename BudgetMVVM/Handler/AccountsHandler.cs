using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetMVVM.ViewModel;

namespace BudgetMVVM.Handler
{
    class AccountsHandler
    {
        // Jon 

        public AccountsViewModel AccountsViewModel { get; set; }
        
        public AccountsHandler(AccountsViewModel accountsViewModel)
        {
            AccountsViewModel = accountsViewModel;
        }
    }
}
