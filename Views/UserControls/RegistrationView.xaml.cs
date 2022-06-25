using System.Windows;
using System.Windows.Controls;

namespace JudoDesktopApp.Views.UserControls
{
    /// <summary>
    /// Interaction logic for RegistrationView.xaml
    /// </summary>
    public partial class RegistrationView : UserControl
    {
        public RegistrationView()
        {
            InitializeComponent();
        }

        private void OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            ((dynamic)DataContext).User.PlainPassword = (sender as PasswordBox).Password;
        }
    }
}
