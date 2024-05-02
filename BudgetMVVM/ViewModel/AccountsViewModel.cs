using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BudgetManager.Model;
using BudgetMVVM.Annotations;
using BudgetMVVM.Handler;
using BudgetMVVM.Model;

namespace BudgetMVVM.ViewModel
{
    class AccountsViewModel
    {
        // Jon

        public AccountsSingleton AccountsSingleton { get; set; }
        public AccountsHandler AccountsHandler { get; set; }
        
        public AccountsViewModel()
        {
            AccountsSingleton = AccountsSingleton.Instance;
            AccountsHandler = new AccountsHandler(this);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
