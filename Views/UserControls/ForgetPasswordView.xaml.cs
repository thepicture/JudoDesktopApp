using System.Windows;
using System.Windows.Controls;

namespace JudoDesktopApp.Views.UserControls
{
    /// <summary>
    /// Interaction logic for ForgetPasswordView.xaml
    /// </summary>
    public partial class ForgetPasswordView : UserControl
    {
        public ForgetPasswordView()
        {
            InitializeComponent();
        }

        private void OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            ((dynamic)DataContext).User.PlainPassword = (sender as PasswordBox).Password;
        }
    }
}
