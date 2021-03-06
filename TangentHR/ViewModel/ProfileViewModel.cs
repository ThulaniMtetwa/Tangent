﻿using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using TangentHR.Models;
using TangentHR.Services;

namespace TangentHR.ViewModel
{
    public class ProfileViewModel: INotifyPropertyChanged
    {

        private ApiServices apiService;
        bool isLoading;

        string fulname, position, address, email;

        public bool IsLoading
        {
            get
            {
                return isLoading;
            }
            set
            {
                if (isLoading != value)
                {
                    isLoading = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Fullname
        {
            get
            {
                return fulname;
            }
            set
            {
                if (fulname != value)
                {
                    fulname = value;
                    OnPropertyChanged();
                }
            }
        }
       
        public string Position
        {
            get
            {
                return position;
            }
            set
            {
                if (position != value)
                {
                    position = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                if (address != value)
                {
                    address = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                if (email != value)
                {
                    email = value;
                    OnPropertyChanged();
                }
            }
        }


        public ProfileViewModel()
        {
            apiService = new ApiServices();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string name = "")
        {
            var changed = PropertyChanged;
            if (changed != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            }
        }

        public async Task GetUserProfile(string userToken)
        { 
            Employee result = await apiService.GetProfileAsync(userToken);

            System.Diagnostics.Debug.WriteLine(result);
            Fullname = result.User.First_name +" "+result.User.Last_name;
            Position = result.Position.Level + " "+result.Position.Name;
            Address = result.Physical_Address;
            Email = result.User.Email;
        }

    }
}
