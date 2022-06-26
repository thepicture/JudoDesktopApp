namespace JudoDesktopApp.Services
{
    public interface IMessageBoxService
    {
        void Inform(string information);
        bool Ask(string question);
    }
}
