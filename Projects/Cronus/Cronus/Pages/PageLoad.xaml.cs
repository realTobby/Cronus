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

            SearchForProjects();
        }

        private void SearchForProjects()
        {
            if(viewModelRef.WorkspacePath != null && viewModelRef.WorkspacePath != string.Empty)
            {
                string[] projectsInsideWorkspace = System.IO.Directory.GetDirectories(viewModelRef.WorkspacePath);

                foreach (string name in projectsInsideWorkspace)
                {
                    ProjectModel nextProject = FileManager.LoadProject(name);

                    viewModelRef.AvailableProjects.Add(nextProject);

                }
            }
            


        }
    }
}
