using JudoDesktopApp.Commands;
using JudoDesktopApp.Models.Entities;
using System.Windows.Input;

namespace JudoDesktopApp.ViewModels
{
    public class RegistrationViewModel : ViewModelBase
    {

        private Command signUpCommand;

        public RegistrationViewModel()
        {
            Title = "Окно создания нового аккаунта";
            User = new User();
        }

        public ICommand SignUpCommand
        {
            get
            {
                if (signUpCommand == null)
                {
                    signUpCommand = new Command(SignUp);
                }

                return signUpCommand;
            }
        }

        public User User { get; set; }

        private void SignUp()
        {
        }
    }
}