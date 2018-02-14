using System;
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

        public async Task<Employee> GetUserProfile(string userToken)
        { 
            Employee result = await apiService.GetProfileAsync(userToken);


            Fullname = result.user.First_name + ' ' + result.user.Last_name;
            Position = result.position.Level +' '+ result.position.Name;
            Address = result.Physical_Address;
            Email = result.user.Email;
           
            return result;
        }

    }
}
