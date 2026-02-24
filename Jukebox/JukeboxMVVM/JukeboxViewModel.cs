using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using Windows.Media.Core;
using Windows.Media.Playback;

namespace Jukebox.JukeboxMVVM
{
    internal class JukeboxViewModel
    {
        public ObservableCollection<TrackModel> _tracks = new ObservableCollection<TrackModel>();

        private MediaPlayer _trackPlayer = new MediaPlayer();

        private int currItemIndex = 0;

        public int CurrItemIndex
        {
            get => currItemIndex;
            set
            {
                this._tracks[currItemIndex].AudioSelected = false;
                currItemIndex = value;
                this._tracks[currItemIndex].AudioSelected = true;
                OnPropertyChanged(nameof(CurrItemIndex));
            }
        }


        void InitializeValues()
        {

            for (int i = 0; i < 10; i++)
            {
                TrackModel track = new TrackModel();
                this._tracks.Add(track);
            }

            this._tracks[currItemIndex].AudioSelected = true;

        UpdateSelection();
        }

        public void UpdateSelection(int newSelection = 0)
        {
            if(newSelection != -1)
            {
                CurrItemIndex = newSelection;
                _trackPlayer.Source = MediaSource.CreateFromUri(_tracks[CurrItemIndex].AudioFile);
                _trackPlayer.Play();
            }
        }

        public void AddButton_Click()
        {
            Debug.WriteLine("test");
            TrackModel track = new TrackModel();
            this._tracks.Add(track);
        }
        public void DeleteButton_Click()
        {
            if (CurrItemIndex != -1)
            {
                _tracks.RemoveAt(CurrItemIndex);
            }

            if (this._tracks.Count != 0)
            {
                UpdateSelection();
            }
        }
        public void ShuffleButton_Click()
        {
            // create random number in list range
            Random rnd = new Random();
            int newIndex = rnd.Next(0, this._tracks.Count);

            // ensure new random number is not previous number
            while (newIndex == CurrItemIndex)
            {
                newIndex = rnd.Next(0, this._tracks.Count - 1);
            }

            UpdateSelection(newIndex);
        }
    
        public void AudioFileListView_Loaded()
        {
            InitializeValues();
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
