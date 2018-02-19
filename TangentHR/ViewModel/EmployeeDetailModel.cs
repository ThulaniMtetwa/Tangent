using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TangentHR.Models;

namespace TangentHR.ViewModel
{
    public class EmployeeDetailModel: INotifyPropertyChanged
    {

        string fulname,
         postion,
         email;
        bool isEmployed;

        public EmployeeDetailModel(Employee employee)
        {
            Fullname =  employee.User.First_name;
            Position = employee.Position.Level + " " + employee.Position.Name;
            IsEmployeed = employee.User.Is_staff;
            Email = employee.Email;
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
                return postion;
            }
            set
            {
                if (postion != value)
                {
                    postion = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool IsEmployeed
        {
            get
            {
                return isEmployed;
            }
            set
            {
                if (isEmployed != value)
                {
                    isEmployed = value;
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

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string name = "")
        {
            var changed = PropertyChanged;
            if (changed != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            }
        }


    }
}
