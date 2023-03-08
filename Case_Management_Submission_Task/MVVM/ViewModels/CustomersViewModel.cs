using Case_Management_Submission_Task.Helpers;
using Case_Management_Submission_Task.MVVM.Models;
using Case_Management_Submission_Task.Services;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;

namespace Case_Management_Submission_Task.MVVM.ViewModels
{
    internal class CustomersViewModel : ObservableObject
    {
        private readonly NavigationStore _navigationStore;
        private readonly CustomerService _customerService;
        private ObservableCollection<CustomerModel> _customers;
        private CustomerModel _selectedCustomer;

        public CustomersViewModel(NavigationStore navigationStore, CustomerService customerService)
        {
            _navigationStore = navigationStore;
            _customerService = customerService;
            _customers = new ObservableCollection<CustomerModel>();
            _selectedCustomer = default(CustomerModel)!;

            NavigateToCreateCaseCommand = new NavigateCommand<CreateCaseViewModel>(navigationStore, () => new CreateCaseViewModel(_navigationStore, _customerService, _selectedCustomer));

            LoadCustomersAsync().ConfigureAwait(false);
        }

        public ObservableCollection<CustomerModel> Customers
        {
            get { return _customers; }
            set { _customers = value; }
        }

        public CustomerModel SelectedCustomer
        {
            get => _selectedCustomer;
            set
            {
                _selectedCustomer = value;
            }
        }

        public async Task LoadCustomersAsync()
        {
            var _customers = await _customerService.GetAllAsync();

            if (_customers != null)
            {
                foreach (var customer in _customers)
                    Customers.Add(customer);
            }
        }

        public ICommand NavigateToCreateCaseCommand { get; }
    }
}
