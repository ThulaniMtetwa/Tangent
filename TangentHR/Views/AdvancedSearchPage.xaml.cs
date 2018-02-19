using System;
using System.Collections.Generic;
using TangentHR.ViewModel;
using Xamarin.Forms;

namespace TangentHR.Views
{
    public partial class AdvancedSearchPage : ContentPage
    {
        AdvancedSearchModel search;
        EmployeesViewModel employees;

        public AdvancedSearchPage()
        {
            InitializeComponent();

            search = new AdvancedSearchModel();
            employees = new EmployeesViewModel();

            BindingContext = search;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await search.GetEmployees();
        }

        static void Callback(int s){
            System.Diagnostics.Debug.WriteLine("Result", s);
        }

        void GoToList(object sender, System.EventArgs e)
        {
            var em = new EmployeeListPage();


            Navigation.PopAsync();
        }
        void Click(object sender, System.EventArgs e)
        {
            search.Detail();
        }

    }
}
