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


        async void SignInAsync(object sender, EventArgs e)
        {

            try
            {
                var result = await login.IsValidLogin();

                if (result.Item1)
                {

                    Application.Current.Properties["token"] = result.Item3.token;

                    //Navigation.InsertPageBefore(new TabbedNavPage(), this);

                    //await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("Information", result.Item2, "OK");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }
    }
}
