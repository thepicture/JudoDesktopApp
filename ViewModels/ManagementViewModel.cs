using JudoDesktopApp.Commands;
using System.Windows.Input;

namespace JudoDesktopApp.ViewModels
{
    public class ManagementViewModel : ViewModelBase
    {
        public ManagementViewModel()
        {
            Title = "Окно управления";
        }

        private Command goToParticipantsCommand;

        public ICommand GoToParticipantsCommand
        {
            get
            {
                if (goToParticipantsCommand == null)
                {
                    goToParticipantsCommand = new Command(GoToParticipants);
                }

                return goToParticipantsCommand;
            }
        }

        private void GoToParticipants()
        {
            Navigator.Go<ParticipantsViewModel>();
        }
    }
}