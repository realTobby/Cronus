using Cronus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Cronus.ViewModels
{
    public class ViewModel : BaseNotifier
    {
        #region Private Fields
        private string _versionTitle = string.Empty;

        private Page _currentView;
        private int _selectedMenuIndex = 0;

        private bool _isFirstStart = false;

        private string _newProjectName = string.Empty;
        private string _newProjectAuthor = string.Empty;
        private string _newProjectDescription = string.Empty;

        private string _workspacePath = string.Empty;
        private ProjectModel _loadedProject = null;

        private List<ProjectModel> _availableProjects = new List<ProjectModel>();

        #endregion

        #region Public Properties
        public string VersionTitle
        {
            get
            {
                return _versionTitle;
            }
            set
            {
                _versionTitle = value;
                base.OnPropertyChanged(nameof(VersionTitle));
            }
        }

        public Page CurrentView
        {
            get
            {
                return _currentView;
            }
            set
            {
                _currentView = value;
                base.OnPropertyChanged(nameof(CurrentView));
            }
        }

        public int SelectedMenuIndex
        {
            get
            {
                return _selectedMenuIndex;
            }
            set
            {
                _selectedMenuIndex = value;
                base.OnPropertyChanged(nameof(SelectedMenuIndex));
            }
        }

        public bool IsFirstStart
        {
            get
            {
                return _isFirstStart;
            }
            set
            {
                _isFirstStart = value;
                base.OnPropertyChanged(nameof(IsFirstStart));
            }
        }

        public string NewProjectName
        {
            get
            {
                return _newProjectName;
            }
            set
            {
                _newProjectName = value;
                base.OnPropertyChanged(nameof(NewProjectName));
            }
        }

        public string NewProjectAuthor
        {
            get
            {
                return _newProjectAuthor;
            }
            set
            {
                _newProjectAuthor = value;
                base.OnPropertyChanged(nameof(NewProjectAuthor));
            }
        }

        public string NewProjectDescription
        {
            get
            {
                return _newProjectDescription;
            }
            set
            {
                _newProjectDescription = value;
                base.OnPropertyChanged(nameof(NewProjectDescription));
            }
        }

        public string WorkspacePath
        {
            get
            {
                return _workspacePath;
            }
            set
            {
                _workspacePath = value;
                base.OnPropertyChanged(nameof(WorkspacePath));
            }
        }

        public ProjectModel LoadedProject
        {
            get
            {
                return _loadedProject;
            }
            set
            {
                _loadedProject = value;
                base.OnPropertyChanged(nameof(LoadedProject));
            }
        }

        public List<ProjectModel> AvailableProjects
        {
            get
            {
                return _availableProjects;
            }
            set
            {
                _availableProjects = value;
                base.OnPropertyChanged(nameof(AvailableProjects));
            }
        }

        #endregion

    }
}
