using AppBienvenida.Models;
using Microsoft.Maui.Controls;
using System;
using System.Collections;
using System.Diagnostics;

namespace AppBienvenida
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}