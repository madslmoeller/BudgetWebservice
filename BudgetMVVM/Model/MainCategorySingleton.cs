using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.ServiceModel.Channels;
using Windows.UI.Popups;
using BudgetMVVM.Annotations;


namespace BudgetMVVM.Model
{
    class MainCatagorySingleton : INotifyPropertyChanged
    {
        // Bipin

        private static MainCatagorySingleton singleton = new MainCatagorySingleton();
        private ObservableCollection<MainCatagory> _catagories;

        public ObservableCollection<MainCatagory> Catagories
        {
            get { return _catagories; }
            set
            {
                _catagories = value;
                OnPropertyChanged();
            }
        }

        public static MainCatagorySingleton Instance
        {
            get { return singleton; }
        }

        private MainCatagorySingleton()
        {
            Catagories = new ObservableCollection<MainCatagory>(new PersistenceFacade().GetCatagories());
        }

        public void CreateCatagory(MainCatagory c)
        {
            new PersistenceFacade().SaveCategory(c);
            Catagories.Clear();
            //Catagories.Add(c);

            Catagories = new ObservableCollection<MainCatagory>(new PersistenceFacade().GetCatagories());
        }

        public void DeleteCatagory(MainCatagory d)
        {
            new PersistenceFacade().DeleteCatagories(d);
            Catagories.Remove(d);
            new PersistenceFacade().GetCatagories();
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
