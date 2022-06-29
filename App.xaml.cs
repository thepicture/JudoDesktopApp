using JudoDesktopApp.Models.Entities;
using JudoDesktopApp.ViewModels;
using System;
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

            try
            {
                using (JudoBaseEntities entities = new JudoBaseEntities())
                {
                    entities.Database.Connection.Open();
                }
            }
            catch (Exception)
            {
                ViewModelBase.MessageBox.Inform("База данных недоступна, исправьте строку подключения в App.config");
                Environment.Exit(0);
            }

            NavigationWindow navigationWindow = new NavigationWindow()
            {
                DataContext = new NavigationViewModel()
            };
            ViewModelBase.Navigator.Go<LoginViewModel>();
            navigationWindow.Show();
            navigationWindow.FontFamily = new FontFamily("Arial");
        }
    }
}
