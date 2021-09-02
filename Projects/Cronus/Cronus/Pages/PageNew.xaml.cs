using Cronus.Logic;
using Cronus.Models;
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
            ProjectModel pm = new ProjectModel();
            pm.Name = vm.NewProjectName;
            pm.Author = vm.NewProjectAuthor;
            pm.Description = vm.NewProjectDescription;
            pm.CreateDate = DateTime.Now;
            pm.ChangeDate = DateTime.Now;

            string fullPath = System.IO.Path.Combine(FileManager.GetWorkspacePath(), pm.Name);

            FileManager.CreateNewProject(pm);

            vm.ZPLCode = FileManager.LoadZPL(fullPath);

            CleanPage();

            vm.SelectedMenuIndex = 3;
        }

        private void CleanPage()
        {
            txtBox_projectName.Text = string.Empty;
            txtBox_projectAuthor.Text = string.Empty;
            txtBox_projectDescription.Text = string.Empty;
        }
    }
}
