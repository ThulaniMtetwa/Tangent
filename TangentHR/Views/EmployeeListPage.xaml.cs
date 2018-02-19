using System;
using System.Collections.Generic;
using TangentHR.Models;
using TangentHR.ViewModel;
using Xamarin.Forms;

namespace TangentHR.Views
{
    public partial class EmployeeListPage : ContentPage
    {
        EmployeesViewModel employee;

        public EmployeeListPage()
        {
            InitializeComponent();
            employee = new EmployeesViewModel();
            BindingContext = employee;


        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            if (Application.Current.Properties.ContainsKey("token"))
            {
                var id =  Application.Current.Properties["token"] as string;
                // do something with id
                var result = await employee.GetEmployees(id);
                //listView.ItemsSource = result;
            }

            AdvancedSearchModel search = new AdvancedSearchModel();

            search.LongRunning(Callback);
        }

        static void Callback(int result){
            System.Diagnostics.Debug.WriteLine("Result",result);

            //Call api service with new parameters
        }

        public void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var p = e.SelectedItem as Employee;
            var em = new EmployeePage();

            var emd = new EmployeeDetailModel (p);
            em.BindingContext = emd;
            Navigation.PushAsync(em);

        }

        void AdvancedSearch(object sender, System.EventArgs e)
        {
            var em = new AdvancedSearchPage();
            Navigation.PushAsync(em);
        }
    }
}
