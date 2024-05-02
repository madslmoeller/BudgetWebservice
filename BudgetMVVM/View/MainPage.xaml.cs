using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace BudgetMVVM.View
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            Mainframe.Navigate(typeof(AccountsPage));
        }

        public void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }




        private void AccountsButton_Click(object sender, RoutedEventArgs e)
        {
            Mainframe.Navigate(typeof(AccountsPage));
        }
        public void InvoiceButton_Click(object sender, RoutedEventArgs e)
        {
            Mainframe.Navigate(typeof(InvoicePage));
        }

        public void LineItemButton_Click(object sender, RoutedEventArgs e)
        {
            Mainframe.Navigate(typeof(LineItemPage));
        }

        public void MainCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            Mainframe.Navigate(typeof(MainCategoryPage));
        }

        public void SubCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            Mainframe.Navigate(typeof(SubCategoryPage)); ;
        }










        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            if (Mainframe.CanGoBack)
            {
                Mainframe.GoBack();
            }
        }
    }
}
