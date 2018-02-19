using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using TangentHR.Services;

namespace TangentHR.ViewModel
{
    public class AdvancedSearchModel: INotifyPropertyChanged
    {
        private ApiServices apiService;
        string email;
        public delegate void Callback(int s);

        public AdvancedSearchModel()
        {
            apiService = new ApiServices();
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

        public async Task GetEmployees(){

            var result = await apiService.GetSearchedEmployeesAsync("2a3d1af2f3f6d1cddaa3012c1c465fcbdffa3678","prav");

            EmployeesViewModel list = new EmployeesViewModel();

            list.EmployeesList = result;


        }

       
        public void Detail(){
            System.Diagnostics.Debug.WriteLine(Email);
        }

        public void LongRunning(Callback obj)
        {
            obj(10);
        }

    }
}
