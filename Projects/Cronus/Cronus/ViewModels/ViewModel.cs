namespace Cronus.ViewModels
{
    public class ViewModel : BaseNotifier
    {
        #region Private Fields
        private string _versionTitle = string.Empty;
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

        #endregion

    }
}
