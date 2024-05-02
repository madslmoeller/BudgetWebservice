using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetMVVM.Model
{
    class AccountsSingleton
    {
        // Jon

        private static AccountsSingleton instance = new AccountsSingleton();

        public static AccountsSingleton Instance
        {
            get { return instance; }
        }

        public ObservableCollection<Account> Accounts { get; set; }

        private AccountsSingleton()
        {
            Accounts = new ObservableCollection<Account>(new PersistenceFacade().GetAccountsCurrentYear());
        }
    }
}