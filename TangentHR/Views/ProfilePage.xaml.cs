using System;
using System.Collections.Generic;
using TangentHR.Models;
using TangentHR.ViewModel;
using Xamarin.Forms;

namespace TangentHR.Views
{
    public partial class ProfilePage : ContentPage
    {

        ProfileViewModel profile;

        public ProfilePage()
        {
            InitializeComponent();
            profile = new ProfileViewModel();
            BindingContext = profile;
          
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            if (Application.Current.Properties.ContainsKey("token"))
            {
                var id = Application.Current.Properties["token"] as string;
                // do something with id
                await profile.GetUserProfile(id);
            }
        }
    }
}
