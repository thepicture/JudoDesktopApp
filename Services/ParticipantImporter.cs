using JudoDesktopApp.Models.Entities;
using JudoDesktopApp.Models.Import;
using Microsoft.Win32;
using System;
using System.Globalization;
using System.IO;
using System.Linq;

namespace JudoDesktopApp.Services
{
    public class ParticipantImporter
    {
        public ImportResult Import()
        {
            OpenFileDialog participantsDialog = new OpenFileDialog
            {
                Title = "Выберите файл с данными участников"
            };

            bool? isSelectedFile = participantsDialog.ShowDialog();
            if (isSelectedFile.HasValue && isSelectedFile.Value)
            {
                string fileFormat = participantsDialog.SafeFileName
                    .Split('.')
                    .Last();
                if (fileFormat == "txt")
                {
                    return ParseCommaSeparatedFile(participantsDialog.FileName);
                }
                else if (fileFormat == "csv")
                {
                    return ParseSemicolonSeparatedFile(participantsDialog.FileName);
                }
                else if (fileFormat == "xlsx")
                {
                    return ParseExcelFile(participantsDialog.FileName);
                }
                else
                {
                    return new ImportResult();
                }
            }
            else
            {
                return new ImportResult();
            }
        }

        private ImportResult ParseExcelFile(string fileName)
        {
            throw new NotImplementedException();
        }

        private ImportResult ParseSemicolonSeparatedFile(string fileName)
        {
            string[] lines = File.ReadAllLines(fileName)
                .Skip(1)
                .ToArray();

            int recordsCount = lines.Length;
            int importedRecordsCount = 0;

            foreach (string line in lines)
            {
                try
                {
                    ExtractValuesFromSemicolonFile(line);
                    ++importedRecordsCount;
                }
                catch (Exception)
                {
                    continue;
                }
            }
            return new ImportResult
            {
                RecordsCount = recordsCount,
                ImportedRecordsCount = importedRecordsCount
            };
        }

        private void ExtractValuesFromSemicolonFile(string line)
        {
            using (JudoBaseEntities entities = new JudoBaseEntities())
            {
                string[] values = line.Split(';');
                Participant participant = new Participant
                {
                    FirstName = values[1].Split(',')[1].Trim(),
                    LastName = values[1].Split(',')[0].Trim(),
                    GenderId = values[2].Trim() == "m" ? 1 : 2,
                    BirthDate = DateTime.ParseExact(values[3].Trim(), "dd.MM.yyyy", CultureInfo.InvariantCulture),
                    PostCode = values[6].Split(new string[] { " " }, StringSplitOptions.None)[0],
                    WeightInPounds = decimal.Parse(values[8])
                };

                string cityTitle = values[4].Trim();
                if (!entities.Cities.Any(h => h.Title == cityTitle))
                {
                    City hometown = new City
                    {
                        Title = cityTitle
                    };
                    entities.Cities.Add(hometown);
                    entities.SaveChanges();
                    participant.CityId = hometown.Id;
                }
                else
                {
                    participant.CityId = entities.Cities.First(c => c.Title == cityTitle).Id;
                }

                string clubTitle = values[7].Trim();
                if (!entities.SportsClubs.Any(c => c.Title == clubTitle))
                {
                    SportsClub club = new SportsClub
                    {
                        Title = clubTitle
                    };
                    entities.SportsClubs.Add(club);
                    entities.SaveChanges();
                    participant.SportsClubId = club.Id;
                }
                else
                {
                    participant.SportsClubId = entities.SportsClubs.First(s => s.Title == clubTitle).Id;
                }

                entities.Participants.Add(participant);
                entities.SaveChanges();
            }
        }

        private ImportResult ParseCommaSeparatedFile(string fileName)
        {
            string[] lines = File.ReadAllLines(fileName);

            int recordsCount = lines.Length;
            int importedRecordsCount = 0;

            foreach (string line in lines)
            {
                try
                {
                    ExtractValuesFromCommaFile(line);
                    ++importedRecordsCount;
                }
                catch (Exception)
                {
                    continue;
                }
            }
            return new ImportResult
            {
                RecordsCount = recordsCount,
                ImportedRecordsCount = importedRecordsCount
            };
        }

        private static void ExtractValuesFromCommaFile(string line)
        {
            using (JudoBaseEntities entities = new JudoBaseEntities())
            {
                string[] values = line.Split(new char[] { ',', ';', ':' });
                Participant participant = new Participant
                {
                    FirstName = values[0].Trim(),
                    LastName = values[1].Trim(),
                    GenderId = values[2].Trim() == "m" ? 1 : 2,
                    BirthDate = DateTime.ParseExact(values[3].Trim(), "dd.MM.yyyy", CultureInfo.InvariantCulture),
                    PostCode = "123456",
                    WeightInPounds = decimal.Parse(values[6].Split(new string[] { " " }, StringSplitOptions.None).Last())
                };

                string cityTitle = values[4].Trim();
                if (!entities.Cities.Any(h => h.Title == cityTitle))
                {
                    City hometown = new City
                    {
                        Title = cityTitle
                    };
                    entities.Cities.Add(hometown);
                    entities.SaveChanges();
                    participant.CityId = hometown.Id;
                }
                else
                {
                    participant.CityId = entities.Cities.First(c => c.Title == cityTitle).Id;
                }

                string clubTitle = string
                    .Join(" ", values[6].Split(new string[] { " " }, StringSplitOptions.None).Reverse().Skip(1).Reverse());
                if (!entities.SportsClubs.Any(c => c.Title == clubTitle))
                {
                    SportsClub club = new SportsClub
                    {
                        Title = clubTitle
                    };
                    entities.SportsClubs.Add(club);
                    entities.SaveChanges();
                    participant.SportsClubId = club.Id;
                }
                else
                {
                    participant.SportsClubId = entities.SportsClubs.First(s => s.Title == clubTitle).Id;
                }

                entities.Participants.Add(participant);
                entities.SaveChanges();
            }
        }
    }
}