using JudoDesktopApp.Commands;
using JudoDesktopApp.Models.Observable;
using JudoDesktopApp.Repositories;
using JudoDesktopApp.Services;
using System.Windows.Input;

namespace JudoDesktopApp.ViewModels
{
    public class ViewModelBase : ObservableObject
    {
        private string title;

        public string Title { get => title; set => SetProperty(ref title, value); }

        private ViewModelBase viewModel;

        public ViewModelBase ViewModel { get => viewModel; set => SetProperty(ref viewModel, value); }

        #region implementations
        public static readonly IMessageBoxService MessageBox = new MessageBoxService();
        public static readonly IUserRepository UserRepository = new UserRepository(new DbContext());
        public static readonly INavigator Navigator = new Navigator();
        #endregion


        private Command goBackCommand;

        public ICommand GoBackCommand
        {
            get
            {
                if (goBackCommand == null)
                {
                    goBackCommand = new Command(GoBack);
                }

                return goBackCommand;
            }
        }

        private void GoBack()
        {
            Navigator.GoBack();
        }
    }
}
