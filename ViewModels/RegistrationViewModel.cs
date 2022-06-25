using JudoDesktopApp.Commands;
using JudoDesktopApp.Models.Entities;
using System.Windows.Input;

namespace JudoDesktopApp.ViewModels
{
    public class RegistrationViewModel : ViewModelBase
    {
        public User User { get; set; }

        public RegistrationViewModel()
        {
            Title = "Окно создания нового аккаунта";
            User = new User();
        }

        private Command signUpCommand;

        public ICommand SignUpCommand
        {
            get
            {
                if (signUpCommand == null)
                {
                    signUpCommand = new Command(SignUpAsync);
                }

                return signUpCommand;
            }
        }

        private async void SignUpAsync()
        {
            if (await RegistrationRepository.IsSignedUpAsync(User))
            {
                MessageBox.Inform("Вы создали новый аккаунт");
            }
            else
            {
                MessageBox.Inform("Введите имя пользователя и пароль");
            }
        }
    }
}