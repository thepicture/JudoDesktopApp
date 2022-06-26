using System.Windows;

namespace JudoDesktopApp.Services
{
    public class MessageBoxService : IMessageBoxService
    {
        public bool Ask(string question)
        {
            return MessageBox.Show(question,
                            "Подтвердите действие",
                            MessageBoxButton.YesNo,
                            MessageBoxImage.Question) == MessageBoxResult.Yes;
        }

        public void Inform(string information)
        {
            MessageBox.Show(information,
                            "Информация",
                            MessageBoxButton.OK,
                            MessageBoxImage.Information);
        }
    }
}
