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

namespace Cronus.Pages
{
    /// <summary>
    /// Interaktionslogik für PageNew.xaml
    /// </summary>
    public partial class PageNew : Page
    {
        ViewModels.ViewModel vm;

        public PageNew(ViewModels.ViewModel viewmodel)
        {
            InitializeComponent();
            vm = viewmodel;
            this.DataContext = vm;
        }

        private void btn_create_new_Click(object sender, RoutedEventArgs e)
        {
            vm.SelectedMenuIndex = 3;
        }
    }
}
