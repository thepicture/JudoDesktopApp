using JudoDesktopApp.Commands;
using JudoDesktopApp.Models.Entities;
using System.Windows.Input;

namespace JudoDesktopApp.ViewModels
{
    public class ChangePasswordViewModel : ViewModelBase
    {

        public User User { get; set; }
        public string OldPlainPassword { get; set; }
        public string NewPlainPassword { get; set; }

        private Command changePasswordCommand;

        public ChangePasswordViewModel()
        {
            Title = "Окно изменения пароля";
            User = new User();
        }

        public ICommand ChangePasswordCommand
        {
            get
            {
                if (changePasswordCommand == null)
                {
                    changePasswordCommand = new Command(ChangePasswordAsync, CanChangePasswordExecute);
                }

                return changePasswordCommand;
            }
        }

        private bool CanChangePasswordExecute(object arg)
        {
            return string.IsNullOrEmpty(User.Error) && !string.IsNullOrWhiteSpace(NewPlainPassword);
        }

        private async void ChangePasswordAsync()
        {
            if (await LoginRepository.IsSignedInAsync(User))
            {
                User.PlainPassword = NewPlainPassword;
                if (await PasswordRepository.IsPasswordRecoveredAsync(User))
                {
                    MessageBox.Inform("Вы изменили старый пароль на новый пароль");
                    Navigator.GoBack();
                }
                else
                {
                    MessageBox.Inform("Не удалось изменить пароль. Попробуйте ещё раз");
                }
            }
            else
            {
                MessageBox.Inform("Введите правильное имя пользователя и старый пароль");
            }
        }
    }
}