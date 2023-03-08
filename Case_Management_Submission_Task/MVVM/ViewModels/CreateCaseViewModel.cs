using Case_Management_Submission_Task.MVVM.Models;
using Case_Management_Submission_Task.Services;

namespace Case_Management_Submission_Task.MVVM.ViewModels
{
    internal class CreateCaseViewModel : ObservableObject
    {
        private readonly NavigationStore _navigationStore;
        private readonly CustomerService _customerService;

        private CustomerModel _selectedCustomer = default(CustomerModel)!;
        public CustomerModel SelectedCustomer
        {
            get { return _selectedCustomer; }
            set
            {
                _selectedCustomer = value;
            }
        }

        public CreateCaseViewModel(NavigationStore navigationStore, CustomerService customerService ,CustomerModel customer)
        {
            _navigationStore = navigationStore;
            _customerService = customerService;
            _selectedCustomer = customer;
        }
    }
}
