using Cronus.Logic;
using Cronus.Pages;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Cronus
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private ViewModels.ViewModel myViewModel;

        private NavigationHandler myNavigation;


        public MainWindow()
        {
            InitializeComponent();
            myViewModel = new ViewModels.ViewModel();
            this.DataContext = myViewModel;

            myNavigation = new NavigationHandler(myViewModel);

            myViewModel.VersionTitle = "this is a test";

            mainFrame.Navigate(myNavigation.GetPageAtIndex(0));
        }

        private void menu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            mainFrame.Navigate(myNavigation.GetPageAtIndex(menu.SelectedIndex));
        }
    }
}
