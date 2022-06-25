using JudoDesktopApp.Commands;
using JudoDesktopApp.Models.Entities;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Input;

namespace JudoDesktopApp.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {

        private Command signInCommand;

        public LoginViewModel()
        {
            User = new User();
        }

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

        public User User { get; set; }

        private async void SignInAsync()
        {
            if (await UserRepository.IsSignedInAsync(User))
            {
                MessageBox.Inform("Вы авторизованы");
            }
            else
            {
                MessageBox.Inform("Неверный логин или пароль");
            }
        }
    }
}