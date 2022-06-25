using JudoDesktopApp.Commands;
using JudoDesktopApp.Models.Entities;
using System.Windows.Input;

namespace JudoDesktopApp.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        public User User { get; set; }

        public LoginViewModel()
        {
            Title = "Окно входа";
            User = new User();
        }

        private Command signInCommand;

        public ICommand SignInCommand
        {
            get
            {
                if (signInCommand == null)
                {
                    signInCommand = new Command(SignInAsync);
                }

                return signInCommand;
            }
        }

        private async void SignInAsync()
        {
            if (await LoginRepository.IsSignedInAsync(User))
            {
                MessageBox.Inform("Вы авторизованы");
            }
            else
            {
                MessageBox.Inform("Неверный логин или пароль");
            }
        }

        private Command goToRegistrationViewModelCommand;

        public ICommand GoToRegistrationViewModelCommand
        {
            get
            {
                if (goToRegistrationViewModelCommand == null)
                {
                    goToRegistrationViewModelCommand = new Command(GoToRegistrationViewModel);
                }

                return goToRegistrationViewModelCommand;
            }
        }

        private void GoToRegistrationViewModel()
        {
            Navigator.Go<RegistrationViewModel>();
        }

        private Command goToForgetPasswordViewModel;

        public ICommand GoToForgetPasswordViewModel
        {
            get
            {
                if (goToForgetPasswordViewModel == null)
                {
                    goToForgetPasswordViewModel = new Command(PerformGoToForgetPasswordViewModel);
                }

                return goToForgetPasswordViewModel;
            }
        }

        private void PerformGoToForgetPasswordViewModel()
        {
            Navigator.Go<ForgetPasswordViewModel>();
        }
    }
}