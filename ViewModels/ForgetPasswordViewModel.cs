using JudoDesktopApp.Commands;
using JudoDesktopApp.Models.Entities;
using System.Windows.Input;

namespace JudoDesktopApp.ViewModels
{
    public class ForgetPasswordViewModel : ViewModelBase
    {
        public User User { get; set; }

        public ForgetPasswordViewModel()
        {
            Title = "Окно восстановления забытых паролей";
            User = new User();
        }

        private Command changePasswordCommand;

        public ICommand ChangePasswordCommand
        {
            get
            {
                if (changePasswordCommand == null)
                {
                    changePasswordCommand = new Command(ChangePasswordAsync);
                }

                return changePasswordCommand;
            }
        }

        private async void ChangePasswordAsync()
        {
            if (await PasswordRepository.IsPasswordRecoveredAsync(User))
            {
                MessageBox.Inform("Пароль восстановлен");
            }
            else
            {
                MessageBox.Inform("Пользователь с указанным логином не найден");
            }
        }

        private Command goToLoginViewModelCommand;

        public ICommand GoToLoginViewModelCommand
        {
            get
            {
                if (goToLoginViewModelCommand == null)
                {
                    goToLoginViewModelCommand = new Command(GoToLoginViewModel);
                }

                return goToLoginViewModelCommand;
            }
        }

        private void GoToLoginViewModel()
        {
            Navigator.GoBack();
        }
    }
}