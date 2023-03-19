using Case_Management_Submission_Task.Helpers;
using Case_Management_Submission_Task.MVVM.Models;
using Case_Management_Submission_Task.Services;
using Microsoft.Extensions.Logging;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Case_Management_Submission_Task.MVVM.ViewModels
{
    internal class EditCasesViewModel : ObservableObject
    {
        private readonly NavigationStore _navigationStore;
        private readonly DatabaseService _databaseService;
        private CustomerModel _customer;

        private ObservableCollection<CaseModel> _cases;
        private CaseModel _selectedCase;
        private bool _isPending;
        private bool _isAssigned;
        private bool _isFinished;
        private string? _comment;
        public EditCasesViewModel(NavigationStore navigationStore, DatabaseService databaseService, CustomerModel customer)
        {
            _navigationStore = navigationStore;
            _databaseService = databaseService;
            _customer = customer;

            LoadCasesAsync(customer);

            _cases = new ObservableCollection<CaseModel>();
            _selectedCase = default(CaseModel)!;

            UpdateCaseCommand = new NavigateCommand<CustomersViewModel>(_navigationStore, () =>
            {
                Task.Run(async () =>
                {
                    if (_selectedCase != null)
                    {
                        if (IsPending)
                        {
                            string status = "Pending";
                            await _databaseService.UpdateCaseAsync(_selectedCase, status, _comment!);
                        }
                        else if (IsAssigned)
                        {
                            string status = "Assigned";
                            await _databaseService.UpdateCaseAsync(_selectedCase, status, _comment!);
                        }
                        else if (IsFinished)
                        {
                            await _databaseService.RemoveCaseAsync(_selectedCase);
                            return;
                        }
                        else
                        {
                            MessageBox.Show("No status selected");
                            return;
                        }
                    }
                    else
                        MessageBox.Show("No case selected");

                }).Wait();
                return new CustomersViewModel(_navigationStore, _databaseService);
            });
        }

        public ObservableCollection<CaseModel> Cases
        {
            get { return _cases; }
            set { _cases = value; }
        }

        public CustomerModel Customer
        {
            get { return _customer; }
            set { _customer = value; }
        }

        public CaseModel SelectedCase
        {
            get { return _selectedCase; }
            set { _selectedCase = value; }
        }

        public bool IsPending
        {
            get { return _isPending; }
            set { _isPending = value; }
        }

        public bool IsAssigned
        {
            get { return _isAssigned; }
            set { _isAssigned = value; }
        }

        public bool IsFinished
        {
            get { return _isFinished; }
            set { _isFinished = value; }
        }

        public string Comment
        {
            get { return _comment!; }
            set { _comment = value; }
        }

        public ICommand UpdateCaseCommand { get; }

        private async void LoadCasesAsync(CustomerModel customer)
        {
            if (_customer != null)
            {
                var _result = await _databaseService.GetCasesForCustomerWithCustomerIdAsync(customer.Id);

                foreach (var _case in _result)
                    _cases.Add(_case);
            }
        }
    }
}
