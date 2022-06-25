using System.Windows;

namespace JudoDesktopApp.Services
{
    public class MessageBoxService : IMessageBoxService
    {
        public void Inform(string information)
        {
            MessageBox.Show(information,
                            "Информация",
                            MessageBoxButton.OK,
                            MessageBoxImage.Information);
        }
    }
}
