using MyMusic.Entities;
using MyMusic.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class CreateSongPage : Page
    {
        public CreateSongPage()
        {
            this.InitializeComponent();
        }
        SongService songService = new SongService();
        public async void Save(object sender, RoutedEventArgs e)
        {
            await songService.Save(new Song
            {
                name = txtName.Text,
                description = txtDescription.Text,
                singer = txtSinger.Text,
                author = txtAuthour.Text,
                thumbnail = txtThumbnail.Text,
                link = txtLink.Text,
                message = txtMessage.Text,
            });
        }
    }
}