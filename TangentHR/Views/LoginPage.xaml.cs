using System;
using System.Collections.Generic;
using TangentHR.ViewModel;
using Xamarin.Forms;

namespace TangentHR.Views
{
    public partial class LoginPage : ContentPage
    {
        LoginViewModel login;
        public LoginPage()
        {
            InitializeComponent();
            login = new LoginViewModel();
            BindingContext = login;
        }

        void SignIn(object sender, System.EventArgs e)
        {
            login.SetUsername();
        }
    }
}
