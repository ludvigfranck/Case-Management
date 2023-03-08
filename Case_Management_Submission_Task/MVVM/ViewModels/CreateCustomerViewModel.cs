using Case_Management_Submission_Task.Services;

namespace Case_Management_Submission_Task.MVVM.ViewModels
{
    internal class CreateCustomerViewModel : ObservableObject
    {
        private NavigationStore _navigationStore;
        private CustomerService _customerService;

        public CreateCustomerViewModel(NavigationStore navigationStore, CustomerService customerService)
        {
            _navigationStore = navigationStore;
            _customerService = customerService;
        }
    }
}
