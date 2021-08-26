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

        private string _newProjectName = string.Empty;
        private string _newProjectAuthor = string.Empty;
        private string _newProjectDescription = string.Empty;

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

        #endregion

    }
}
