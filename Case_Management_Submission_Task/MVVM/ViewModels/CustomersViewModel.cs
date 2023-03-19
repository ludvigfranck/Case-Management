using Case_Management_Submission_Task.Helpers;
using Case_Management_Submission_Task.MVVM.Models;
using Case_Management_Submission_Task.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Case_Management_Submission_Task.MVVM.ViewModels
{
    internal class CustomersViewModel : ObservableObject
    {
        private readonly NavigationStore _navigationStore;
        private readonly DatabaseService _databaseService;

        private ObservableCollection<CustomerModel> _customers;
        private CustomerModel _selectedCustomer;

        public CustomersViewModel(NavigationStore navigationStore, DatabaseService databaseService)
        {
            _navigationStore = navigationStore;
            _databaseService = databaseService;

            LoadCustomersAsync();

            _customers = new ObservableCollection<CustomerModel>();
            _selectedCustomer = default(CustomerModel)!;

            NavigateToAddCaseCommand = new NavigateCommand<AddCaseViewModel>(navigationStore, () => new AddCaseViewModel(_navigationStore, _databaseService, _selectedCustomer));
            NavigateToEditCasesCommand = new NavigateCommand<EditCasesViewModel>(navigationStore, () => new EditCasesViewModel(_navigationStore, _databaseService, _selectedCustomer));
        }

        public ObservableCollection<CustomerModel> Customers
        {
            get { return _customers; }
            set { _customers = value; }
        }
        public CustomerModel SelectedCustomer
        {
            get { return _selectedCustomer; }
            set { _selectedCustomer = value; }
        }

        public ICommand NavigateToAddCaseCommand { get; }
        public ICommand NavigateToEditCasesCommand { get; }

        private async void LoadCustomersAsync()
        {
            var _result = await _databaseService.GetAllCustomersAsync();
            if (_result != null)
            {
                foreach (var _customer in _result)
                    _customers.Add(_customer);
            }
        }
    }
}
