using MyMusic.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MyMusic.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ListSongPage : Page
    {
        private SongService songService = new SongService();
        public ListSongPage()
        {
            this.InitializeComponent();
            this.Loaded += LoadPost; // document ready trong js
        }

        private async void LoadPost(object sender, RoutedEventArgs e)
        {

            // vuejs, react, angular | desktop application
            var listSong = await songService.FindAll();
            ListData.ItemsSource = listSong;
            Uri pathUri = new Uri(listSong[0].link);
            MyMediaPlayer.Source = MediaSource.CreateFromUri(pathUri);
            MyMediaPlayer.MediaPlayer.Play();
        }
    }
}
