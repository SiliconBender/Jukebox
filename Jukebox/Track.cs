using Microsoft.UI.Xaml.Media.Imaging;
using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Jukebox
{
    public class Track : DependencyObject, INotifyPropertyChanged
    {
        private static Random random = new Random();

        private static List<Uri> audioFiles = new List<Uri>()
            {
                new Uri("ms-appx:///Assets/Audio/Track1.wav"),
                new Uri("ms-appx:///Assets/Audio/Track2.wav"),
                new Uri("ms-appx:///Assets/Audio/Track3.wav"),
                new Uri("ms-appx:///Assets/Audio/Track4.wav")
            };


        private static List<BitmapImage> profilePics = new List<BitmapImage>()
            {
                new BitmapImage(new Uri("ms-appx:///Assets/Thumbnails/SoundWave1.png")),
                new BitmapImage(new Uri("ms-appx:///Assets/Thumbnails/SoundWave2.png")),
                new BitmapImage(new Uri("ms-appx:///Assets/Thumbnails/SoundWave3.png")),
                new BitmapImage(new Uri("ms-appx:///Assets/Thumbnails/SoundWave4.png")),
                new BitmapImage(new Uri("ms-appx:///Assets/Thumbnails/SoundWave5.png")),
                new BitmapImage(new Uri("ms-appx:///Assets/Thumbnails/SoundWave6.png"))
            };

        private static List<string> genres = new List<string>() { "Rock", "Metal", "Punk", "Blues", "Country", "Swing", "Rap", "R&B" };

        private static List<string> names = new List<string>() { "Lilly", "Mukhtar", "Sophie", "Femke", "Abdul-Rafi'", "Chirag-ud-D...", "Mariana", "Aarif", "Sara", "Ibadah", "Fakhr", "Ilene", "Sardar", "Hanna", "Julie", "Iain", "Natalia", "Henrik", "Rasa", "Quentin", "Gadi", "Pernille", "Ishtar", "Jimme", "Justina", "Lale", "Elize", "Rand", "Roshanara", "Rajab", "Bijou", "Marcus", "Marcus", "Alima", "Francisco", "Thaqib", "Andreas", "Mariana", "Amalie", "Rodney", "Dena", "Fadl", "Ammar", "Anna", "Nasreen", "Reem", "Tomas", "Filipa", "Frank", "Bari'ah", "Parvaiz", "Jibran", "Tomas", "Elli", "Carlos", "Diego", "Henrik", "Aruna", "Vahid", "Eliana", "Roxane", "Amanda", "Ingrid", "Wander", "Malika", "Basim", "Eisa", "Alina", "Andreas", "Deeba", "Diya", "Parveen", "Bakr", "Celine", "Bakr", "Marcus", "Daniel", "Mathea", "Edmee", "Hedda", "Maria", "Maja", "Alhasan", "Alina", "Hedda", "Victor", "Aaftab", "Guilherme", "Maria", "Kai", "Sabien", "Abdel", "Fadl", "Bahaar", "Vasco", "Jibran", "Parsa", "Catalina", "Fouad", "Colette" };

        private static List<string> lastnames = new List<string>() { "Carlson", "Attia", "Quint", "Hollenberg", "Khoury", "Araujo", "Hakimi", "Seegers", "Abadi", "al", "Krommenhoek", "Siavashi", "Kvistad", "Sjo", "Vanderslik", "Fernandes", "Dehli", "Sheibani", "Laamers", "Batlouni", "Lyngvær", "Oveisi", "Veenhuizen", "Gardenier", "Siavashi", "Mutlu", "Karzai", "Mousavi", "Natsheh", "Seegers", "Nevland", "Lægreid", "Bishara", "Cunha", "Hotaki", "Kyvik", "Cardoso", "Pilskog", "Pennekamp", "Nuijten", "Bettar", "Borsboom", "Skistad", "Asef", "Sayegh", "Sousa", "Medeiros", "Kregel", "Shamoun", "Behzadi", "Kuzbari", "Ferreira", "Van", "Barros", "Fernandes", "Formo", "Nolet", "Shahrestaani", "Correla", "Amiri", "Sousa", "Fretheim", "Van", "Hamade", "Baba", "Mustafa", "Bishara", "Formo", "Hemmati", "Nader", "Hatami", "Natsheh", "Langen", "Maloof", "Berger", "Ostrem", "Bardsen", "Kramer", "Bekken", "Salcedo", "Holter", "Nader", "Bettar", "Georgsen", "Cunha", "Zardooz", "Araujo", "Batalha", "Antunes", "Vanderhoorn", "Nader", "Abadi", "Siavashi", "Montes", "Sherzai", "Vanderschans", "Neves", "Sarraf", "Kuiters" };


        #region Properties
        public string Id { get; } = Guid.NewGuid().ToString();
        public string Initials => InitialOf(FirstName) + InitialOf(LastName);
        public string Name => FirstName + " " + LastName;
        public string LastName { get; } = GenerateLastName();
        public string FirstName { get; } = GenerateFirstName();
        public string Genre { get; } = GenerateGenre();
        public BitmapImage ImageSource { get; } = GenerateProfilePic();
        public Uri AudioFile { get; } = GenerateAudioFile();

        #endregion

        private bool _AudioSelected = false;
        public bool AudioSelected
        {
            get { return _AudioSelected; }
            set
            {
                if (value != _AudioSelected)
                {
                    _AudioSelected = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public Track()
        {
        }


        #region Public Methods
        public static Track GetNewContact()
        {
            return new Track();
        }
        public static ObservableCollection<Track> GetContacts(int numberOfContacts)
        {
            ObservableCollection<Track> contacts = new ObservableCollection<Track>();

            for (int i = 0; i < numberOfContacts; i++)
            {
                contacts.Add(GetNewContact());
            }
            return contacts;
        }

        public override string ToString()
        {
            return Name;
        }
        #endregion

        #region Helpers
        private static string InitialOf(string word)
        {
            return string.IsNullOrEmpty(word) ? string.Empty : word.Substring(0, 1);
        }

        private static string GenerateGenre()
        {
            return genres[random.Next(0, genres.Count)];
        }

        private static string GenerateFirstName()
        {
            return names[random.Next(0, names.Count)];
        }

        private static string GenerateLastName()
        {
            return lastnames[random.Next(0, lastnames.Count)];
        }
        private static BitmapImage GenerateProfilePic()
        {
            return profilePics[random.Next(0, profilePics.Count)];
        }
        private static Uri GenerateAudioFile()
        {
            return audioFiles[random.Next(0, audioFiles.Count)];
        }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
