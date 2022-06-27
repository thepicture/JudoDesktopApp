using System;
using System.Windows;

namespace JudoDesktopApp.Services
{
    public class Navigator : INavigator
    {
        public event Action Navigated;

        public void GoBack()
        {
            ((NavigationWindow)Application.Current.MainWindow).NavigatorFrame.GoBack();
            Navigated?.Invoke();
        }

        public void Go<T>()
        {
            var viewModel = Activator.CreateInstance(typeof(T));
            if (((NavigationWindow)Application.Current.MainWindow).NavigatorFrame.Navigate(viewModel))
            {
                Navigated?.Invoke();
            }
        }

        public bool IsCanGoBack()
        {
            return ((NavigationWindow)Application.Current.MainWindow).NavigatorFrame.CanGoBack;
        }
    }
}
