using System.Windows;
using System.Windows.Controls;

namespace JudoDesktopApp.Views.UserControls
{
    /// <summary>
    /// Interaction logic for ChangePasswordView.xaml
    /// </summary>
    public partial class ChangePasswordView : UserControl
    {
        public ChangePasswordView()
        {
            InitializeComponent();
        }

        private void OnOldPasswordChanged(object sender, RoutedEventArgs e)
        {
            ((dynamic)DataContext).User.PlainPassword = (sender as PasswordBox).Password;
        }

        private void OnNewPasswordChanged(object sender, RoutedEventArgs e)
        {
            ((dynamic)DataContext).NewPlainPassword = (sender as PasswordBox).Password;
        }
    }
}
