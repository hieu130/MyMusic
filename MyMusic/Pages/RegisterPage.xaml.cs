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
    public sealed partial class RegisterPage : Page
    {
        private AccountService accountService = new AccountService();
        public int chooseGender = 1;
        public RegisterPage()
        {
            this.InitializeComponent();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            switch (radioButton.Tag)
            {
                case "Male":
                    chooseGender = 1;
                    break;
                case "Female":
                    chooseGender = 2;
                    break;
            }
        }
        private async void Save(object sender, RoutedEventArgs e)
        {
            var account = new Account
            {
                firstName = txtFirstName.Text,
                lastName = txtLastName.Text,
                email = txtEmail1.Text,
                password = txtPassword.Password.ToString(),
                phone = txtPhone1.Text,
                address = txtAddress1.Text,
                avatar = txtAvatar1.Text,
                gender = chooseGender,
                birthday = datePickerBirthday1.SelectedDate.Value.ToString("yyyy-MM-dd"),
                introduction = txtIntroduction.Text
            };
            var result = await accountService.Register(account);
            if (result)
            {
                ContentDialog dialog = new ContentDialog();
                dialog.Title = "Acction success";
                dialog.Content = $"Create account success!";
                dialog.PrimaryButtonText = "Ok";
                await dialog.ShowAsync();
                Frame.Navigate(typeof(Pages.ListSongPage));
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
