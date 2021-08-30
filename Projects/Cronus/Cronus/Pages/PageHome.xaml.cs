using Microsoft.WindowsAPICodePack.Dialogs;
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
    /// Interaktionslogik für PageHome.xaml
    /// </summary>
    public partial class PageHome : Page
    {
        private const string REGISTRY_CRONUS_KEY = @"SOFTWARE\Cronus";

        ViewModels.ViewModel vm;
        Microsoft.Win32.RegistryKey cronusRegistryEntry;

        public PageHome(ViewModels.ViewModel viewModel)
        {
            InitializeComponent();

            vm = viewModel;
            this.DataContext = vm;

            

            UpdateHomeView();
            
        }

        private void UpdateHomeView()
        {
            CheckForWorkspace();

            if (vm.IsFirstStart)
            {
                initStack.Visibility = Visibility.Visible;
                welcomeStack.Visibility = Visibility.Hidden;

            }
            else
            {
                initStack.Visibility = Visibility.Hidden;
                welcomeStack.Visibility = Visibility.Visible;
            }
        }

        private void TextBlock_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void CheckForWorkspace()
        {
            vm.IsFirstStart = true;
            cronusRegistryEntry = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(REGISTRY_CRONUS_KEY);
            var registeredWorkspace = cronusRegistryEntry.GetValue("WorkspacePath");
            if(registeredWorkspace != null)
            { 
                if(System.IO.Directory.Exists(registeredWorkspace.ToString()))
                {
                    vm.IsFirstStart = false;
                    vm.WorkspacePath = registeredWorkspace.ToString();
                }
            }
            cronusRegistryEntry.Close();
        }

        private void btn_setWorkspace_Click(object sender, RoutedEventArgs e)
        {
            cronusRegistryEntry = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(REGISTRY_CRONUS_KEY);
            
            var dlg = new CommonOpenFileDialog();
            dlg.Title = "Select a workspace directory";
            dlg.IsFolderPicker = true;
            dlg.InitialDirectory = "C:";

            dlg.AddToMostRecentlyUsedList = false;
            dlg.AllowNonFileSystemItems = false;
            dlg.DefaultDirectory = "C:";
            dlg.EnsureFileExists = true;
            dlg.EnsurePathExists = true;
            dlg.EnsureReadOnly = false;
            dlg.EnsureValidNames = true;
            dlg.Multiselect = false;
            dlg.ShowPlacesList = true;

            if (dlg.ShowDialog() == CommonFileDialogResult.Ok)
            {
                vm.WorkspacePath = dlg.FileName;
                cronusRegistryEntry.SetValue("WorkspacePath", vm.WorkspacePath);
                UpdateHomeView();
            }
            cronusRegistryEntry.Close();
        }
    }
}
