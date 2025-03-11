using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.ObjectModel;
using Windows.ApplicationModel.Contacts;
using Windows.Media.Core;
using Windows.Media.Playback;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Jukebox
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        // private ObservableCollection<Contact> _contact = Contact.GetContacts(10);
        private ObservableCollection<Track> _tracks = new ObservableCollection<Track>();

        //MediaPlayerPresenter _presenter = new MediaPlayerPresenter();   

        int _currItemIndex = 0;
        int _prevItemIndex = 0;


        public MainPage()
        {
            this.InitializeComponent();

        }

        void InitializeValues()
        {

            for (int i = 0; i < 10; i++)
            {
                Track track = new Track();
                this._tracks.Add(track);
            }

            UpdateSelection();
        }

        private void UpdateSelection(int newSelection = 0)
        {
               _currItemIndex = newSelection;
               this._tracks[_currItemIndex].AudioSelected = true;

               if (_prevItemIndex != _currItemIndex && _prevItemIndex >= 0 && _prevItemIndex < _tracks.Count)
                    this._tracks[_prevItemIndex].AudioSelected = false;

               _prevItemIndex = _currItemIndex;
                AudioFileListView.SelectedIndex = _currItemIndex;

            mediaPlayerElement.Source = MediaSource.CreateFromUri(_tracks[_currItemIndex].AudioFile);

        }


        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Track track = new Track();
            this._tracks.Add(track);
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (AudioFileListView.SelectedIndex != -1)
            {
                _tracks.RemoveAt(AudioFileListView.SelectedIndex);
            }

            if(this._tracks.Count != 0)
            {
                UpdateSelection();
            }
        }
        private void ShuffleButton_Click(object sender, RoutedEventArgs e)
        {
            // create random number in list range
            Random rnd = new Random();
            int newIndex = rnd.Next(0, this._tracks.Count - 1);

            // ensure new random number is not previous number
            while (newIndex == AudioFileListView.SelectedIndex)
            {
                newIndex = rnd.Next(0, this._tracks.Count - 1);
            }

            UpdateSelection(newIndex);
        }

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AudioFileListView.SelectedIndex != -1)
            {
                UpdateSelection( AudioFileListView.SelectedIndex);
            }
        }

        private void AudioFileListView_Loaded(object sender, RoutedEventArgs e)
        {
            InitializeValues();
        }
    }
}
