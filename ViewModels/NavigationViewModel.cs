namespace JudoDesktopApp.ViewModels
{
    public class NavigationViewModel : ViewModelBase
    {
        public NavigationViewModel()
        {
            Navigator.Navigated += OnNavigated;
        }

        private void OnNavigated()
        {
            RaisePropertyChanged(nameof(ViewModel));
        }
    }
}