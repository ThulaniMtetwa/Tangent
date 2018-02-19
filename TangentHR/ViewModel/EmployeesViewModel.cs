using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using TangentHR.Models;
using TangentHR.Services;

namespace TangentHR.ViewModel
{
    public class EmployeesViewModel: INotifyPropertyChanged
    {

        private ApiServices apiService;
        public List<Employee> employeesList;
        bool isLoading;

        public EmployeesViewModel()
        {
            apiService = new ApiServices();
        }

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

        public List<Employee> EmployeesList
        {
            get
            {
                return employeesList;
            }
            set
            {
                if (employeesList != value)
                {
                    employeesList = value;
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

        public async Task<List<Employee>> GetEmployees(string userToken)
        {
            isLoading = true;
            EmployeesList = await apiService.GetEmployeesAsync(userToken);
            isLoading = false;

            return EmployeesList;
        }
    }
}
