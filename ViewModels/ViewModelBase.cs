using JudoDesktopApp.Commands;
using JudoDesktopApp.Models.Observable;
using JudoDesktopApp.Repositories;
using JudoDesktopApp.Services;
using System.Windows;
using System.Windows.Input;

namespace JudoDesktopApp.ViewModels
{
    public class ViewModelBase : ObservableObject
    {


        public bool IsBusy
        {
            get => isBusy;
            set => SetProperty(ref isBusy, value);
        }

        private string title;

        public string Title { get => title; set => SetProperty(ref title, value); }

        public static ViewModelBase ViewModel { get; set; }

        #region implementations
        public static readonly IMessageBoxService MessageBox = new MessageBoxService();
        public static readonly DbContext DbContext = new DbContext();

        public static readonly ILoginRepository LoginRepository = new LoginRepository(new DbContext());
        public static readonly IRegistrationRepository RegistrationRepository = new RegistrationRepository(new DbContext());
        public static readonly IPasswordRepository PasswordRepository = new PasswordRepository(new DbContext());

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



        private Command closeAppCommand;
        private bool isBusy;

        public ICommand CloseAppCommand
        {
            get
            {
                if (closeAppCommand == null)
                {
                    closeAppCommand = new Command(CloseApp);
                }

                return closeAppCommand;
            }
        }

        private void CloseApp()
        {
            if (MessageBox.Ask("Закрыть приложение?"))
                Application.Current.Shutdown();
        }
    }
}
