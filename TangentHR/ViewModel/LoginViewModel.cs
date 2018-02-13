using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TangentHR.ViewModel
{
    public class LoginViewModel: INotifyPropertyChanged
    {

        string username, password;
        public LoginViewModel()
        {
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

        public void SetUsername()
        {
            System.Diagnostics.Debug.WriteLine(username);
        }
    }
}
