using Case_Management_Submission_Task.Helpers;
using Case_Management_Submission_Task.MVVM.Models;
using Case_Management_Submission_Task.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Case_Management_Submission_Task.MVVM.ViewModels
{
    internal class MainViewModel : ObservableObject
    {
        private readonly NavigationStore _navigationStore;
        private readonly CustomerService _customerService;

        public ICommand NavigateToCreateCustomerCommand { get; }
        public ICommand NavigateToCustomersCommand { get; }

        public MainViewModel(NavigationStore navigationStore, CustomerService customerService)
        {
            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
            _customerService = customerService;

            NavigateToCreateCustomerCommand = new NavigateCommand<CreateCustomerViewModel>(navigationStore, () => new CreateCustomerViewModel(_navigationStore, _customerService));
            NavigateToCustomersCommand = new NavigateCommand<CustomersViewModel>(navigationStore, () => new CustomersViewModel(_navigationStore, _customerService));
        }

        public ObservableObject CurrentViewModel => _navigationStore.CurrentViewModel;

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
