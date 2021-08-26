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

        #endregion

    }
}
