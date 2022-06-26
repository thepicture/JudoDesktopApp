using System.Windows;
using System.Windows.Media;

namespace JudoDesktopApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            NavigationWindow navigationWindow = new NavigationWindow();
            navigationWindow.Show();
            navigationWindow.FontFamily = new FontFamily("Arial");
        }
    }
}
