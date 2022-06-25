using JudoDesktopApp.ViewModels;
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
            ViewModelBase viewModel = (ViewModelBase)Activator.CreateInstance(typeof(T));
            ((NavigationWindow)Application.Current.MainWindow).NavigatorFrame.Navigate(viewModel);
            Navigated?.Invoke();
        }

        public bool IsCanGoBack()
        {
            return ((NavigationWindow)Application.Current.MainWindow).NavigatorFrame.CanGoBack;
        }
    }
}
