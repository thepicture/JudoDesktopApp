using JudoDesktopApp.Models.Observable;

namespace JudoDesktopApp.ViewModels
{
    public class ViewModelBase : ObservableObject
    {
        private string title;

        public string Title { get => title; set => SetProperty(ref title, value); }

        private ViewModelBase viewModel;

        public ViewModelBase ViewModel { get => viewModel; set => SetProperty(ref viewModel, value); }
    }
}
