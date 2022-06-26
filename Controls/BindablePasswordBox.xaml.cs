using System.Windows;
using System.Windows.Controls;

namespace JudoDesktopApp.Controls
{
    /// <summary>
    /// Interaction logic for BindablePasswordBox.xaml
    /// </summary>
    public partial class BindablePasswordBox : UserControl
    {


        public int MaxLength
        {
            get { return (int)GetValue(MaxLengthProperty); }
            set { SetValue(MaxLengthProperty, value); }
        }

        public static readonly DependencyProperty MaxLengthProperty =
            DependencyProperty.Register("MaxLength",
                                        typeof(int),
                                        typeof(BindablePasswordBox),
                                        new PropertyMetadata(int.MaxValue));



        public string BindablePassword
        {
            get { return (string)GetValue(BindablePasswordProperty); }
            set { SetValue(BindablePasswordProperty, value); }
        }

        public static readonly DependencyProperty BindablePasswordProperty =
            DependencyProperty.Register("BindablePassword",
                                        typeof(string),
                                        typeof(BindablePasswordBox),
                                        new FrameworkPropertyMetadata(default,
                                                                      FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public BindablePasswordBox()
        {
            InitializeComponent();
        }

        private void OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            BindablePassword = (sender as PasswordBox).Password;
        }
    }
}
