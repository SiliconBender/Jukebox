using Jukebox.JukeboxMVVM;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Windows.Media.Core;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Jukebox
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class JukeboxView : Page
    {

        JukeboxViewModel viewModel = new JukeboxViewModel();

        public JukeboxView()
        {
            this.InitializeComponent();

        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.AddButton_Click();
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.DeleteButton_Click();
        }
        private void ShuffleButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.ShuffleButton_Click();
        }

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            viewModel.UpdateSelection(AudioFileListView.SelectedIndex);
        }

        private void AudioFileListView_Loaded(object sender, RoutedEventArgs e)
        {
            viewModel.AudioFileListView_Loaded();
        }

    }
}
