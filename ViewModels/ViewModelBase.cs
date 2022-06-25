using JudoDesktopApp.Models.Observable;
using JudoDesktopApp.Repositories;
using JudoDesktopApp.Services;

namespace JudoDesktopApp.ViewModels
{
    public class ViewModelBase : ObservableObject
    {
        private string title;

        public string Title { get => title; set => SetProperty(ref title, value); }

        private ViewModelBase viewModel;

        public ViewModelBase ViewModel { get => viewModel; set => SetProperty(ref viewModel, value); }

        #region implementations
        public readonly IMessageBoxService MessageBox = new MessageBoxService();
        public readonly IUserRepository UserRepository = new UserRepository(new DbContext());
        #endregion
    }
}
