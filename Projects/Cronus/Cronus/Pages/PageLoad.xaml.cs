using Cronus.Logic;
using Cronus.Models;
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
    /// Interaktionslogik für PageLoad.xaml
    /// </summary>
    public partial class PageLoad : Page
    {
        private ViewModels.ViewModel viewModelRef;
        public PageLoad(ViewModels.ViewModel vm)
        {
            InitializeComponent();
            viewModelRef = vm;
            this.DataContext = viewModelRef;
            viewModelRef.AvailableProjects =  FileManager.SearchForProjects(viewModelRef.WorkspacePath);
        }

        private void btn_load_project_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_delete_selected_project_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("clicked delete on: " + lstBox_workspace_projects.SelectedIndex);
        }


    }
}
