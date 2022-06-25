using System;

namespace JudoDesktopApp.Services
{
    public interface INavigator
    {
        void Go<T>();
        void GoBack();
        bool IsCanGoBack();
        event Action Navigated;
    }
}
