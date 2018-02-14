using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using TangentHR.Models;
using TangentHR.Services;

namespace TangentHR.ViewModel
{
    public class LoginViewModel: INotifyPropertyChanged
    {

        string username, password;
        bool isLoading;

        private ApiServices apiService;

        public LoginViewModel()
        {
            apiService = new ApiServices();
        }

        public string ValidationErrors { get; private set; }

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

        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                if (username != value)
                {
                    username = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                if (password != value)
                {
                    password = value;
                    OnPropertyChanged();
                }
            }
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

        public async Task<Tuple<bool, string, Auth>> IsValidLogin()
        {

            IsLoading = true;

            ValidationErrors = "";
            if (string.IsNullOrEmpty(username))
            {
                ValidationErrors = "Please enter a username.";
            }
            if (string.IsNullOrEmpty(password))
            {
                ValidationErrors += "Please enter a password.";
            }


            Auth auth = await apiService.SignInAsync(Username, Password);

            if (auth.token == null)
            {
                ValidationErrors += "Please ensure you entered the correct credentials.";
                IsLoading = false;
                return Tuple.Create(false, ValidationErrors, auth);

            }
            else
            {
                ValidationErrors += "Succcessful login.";
                IsLoading = false;
                return Tuple.Create(true, ValidationErrors, auth);
            }
        }
    }
}
