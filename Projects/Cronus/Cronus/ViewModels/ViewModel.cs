
using System.Windows.Controls;

namespace Cronus.ViewModels
{
    public class ViewModel : BaseNotifier
    {
        #region Private Fields
        private string _versionTitle = string.Empty;
        private UserControl _selectedUserControl = null;
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

        public UserControl SelectedUserControl
        {
            get
            {
                return _selectedUserControl;
            }
            set
            {
                _selectedUserControl = value;
                base.OnPropertyChanged(nameof(SelectedUserControl));
            }
        }

        #endregion

    }
}
