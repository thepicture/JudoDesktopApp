using JudoDesktopApp.Commands;
using JudoDesktopApp.Models.Entities;
using JudoDesktopApp.Models.Import;
using JudoDesktopApp.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Windows.Input;

namespace JudoDesktopApp.ViewModels
{
    public class ParticipantsViewModel : ViewModelBase
    {
        private readonly ParticipantImporter participantImporter = new ParticipantImporter();

        public ParticipantsViewModel()
        {
            Title = "Участники";
            ReloadParticipantsAsync();
        }

        private ObservableCollection<Participant> participants;

        public ObservableCollection<Participant> Participants
        {
            get => participants;
            set => SetProperty(ref participants, value);
        }

        private Command importParticipantsCommand;

        public ICommand ImportParticipantsCommand
        {
            get
            {
                if (importParticipantsCommand == null)
                {
                    importParticipantsCommand = new Command(ImportParticipants);
                }

                return importParticipantsCommand;
            }
        }

        private void ImportParticipants()
        {
            ImportResult importResult = participantImporter.Import();
            MessageBox.Inform($"Импортировано {importResult.ImportedRecordsCount} записей из {importResult.RecordsCount} записей");
            ReloadParticipantsAsync();
        }

        private async void ReloadParticipantsAsync()
        {
            using (JudoBaseEntities entities = DbContext.GetNewInstance())
            {
                List<Participant> participants = await entities.Participants.ToListAsync();
                Participants = new ObservableCollection<Participant>(participants);
            }
        }
    }
}