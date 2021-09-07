namespace Cronus
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private ViewModels.ViewModel originalViewModel;

        public MainWindow()
        {
            originalViewModel = new ViewModels.ViewModel();

            InitializeComponent();
#if DEBUG
            originalViewModel.VersionTitle = "Cronus v0.0 [DEV]";
#elif DEBUG
            originalViewModel.VersionTitle = "Cronus v0.0 [RELEASE]";      
#endif

        }

    }
}
