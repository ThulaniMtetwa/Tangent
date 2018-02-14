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

        string fulname, position, address, email, kin_fullname, kin_address, kin_email, salary;

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
        public string Kin_fullname
        {
            get
            {
                return kin_fullname;
            }
            set
            {
                if (kin_fullname != value)
                {
                    kin_fullname = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Kin_address
        {
            get
            {
                return kin_address;
            }
            set
            {
                if (kin_address != value)
                {
                    kin_address = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Kin_email
        {
            get
            {
                return kin_email;
            }
            set
            {
                if (kin_email != value)
                {
                    kin_email = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Salary
        {
            get
            {
                return salary;
            }
            set
            {
                if (salary != value)
                {
                    salary = value;
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
