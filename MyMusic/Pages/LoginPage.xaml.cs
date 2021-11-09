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
    public sealed partial class LoginPage : Page
    {
        private AccountService accountService = new AccountService();
        public LoginPage()
        {
            this.InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
           var result = await accountService.Login(txtEmail.Text,
            txtPassword.Password.ToString());
            if (result)
            {
                ContentDialog dialog = new ContentDialog();
                dialog.Title = "Acction success";
                dialog.Content = $"Login success!";
                dialog.PrimaryButtonText = "Ok";
                await dialog.ShowAsync();
                Frame.Navigate(typeof(Pages.ListSongPage));
            }
        }
    }
}
