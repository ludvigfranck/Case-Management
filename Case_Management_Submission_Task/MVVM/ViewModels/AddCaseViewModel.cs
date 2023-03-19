using Case_Management_Submission_Task.Helpers;
using Case_Management_Submission_Task.MVVM.Models;
using Case_Management_Submission_Task.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Case_Management_Submission_Task.MVVM.ViewModels
{
    internal class AddCaseViewModel : ObservableObject
    {
        private readonly NavigationStore _navigationStore;
        private readonly DatabaseService _databaseService;
        
        private CustomerModel _customer;
        private CaseModel _case;
        private DeviceModel _selectedDevice;
        private ObservableCollection<DeviceModel> _devices;

        public AddCaseViewModel(NavigationStore navigationStore, DatabaseService databaseService, CustomerModel customer)
        {
            _navigationStore = navigationStore;
            _databaseService = databaseService;

            LoadDevicesAsync(customer);
            
            _customer = customer;
            _case = new CaseModel();
            _selectedDevice = new DeviceModel();
            _devices = new ObservableCollection<DeviceModel>();

            CreateCaseCommand = new NavigateCommand<CustomersViewModel>(_navigationStore, () =>
            {
                Task.Run(async () =>
                {
                    await _databaseService.CreateCaseAsync(Case, Customer, SelectedDevice);
                }).Wait();

                return new CustomersViewModel(_navigationStore, _databaseService);
            });
        }

        public CustomerModel Customer
        {
            get { return _customer; }
            set { _customer = value; }
        }

        public CaseModel Case
        {
            get { return _case; }
            set { _case = value; }
        }

        public DeviceModel SelectedDevice
        {
            get { return _selectedDevice; }
            set { _selectedDevice = value; }
        }

        public ObservableCollection<DeviceModel> Devices
        {
            get { return _devices; }
            set { _devices = value; }
        }

        public ICommand CreateCaseCommand { get; }

        private async void LoadDevicesAsync(CustomerModel customer)
        {
            var _result = await _databaseService.GetSpecificCustomerDevices(customer);
            if(_result != null ) 
            { 
                foreach(var _device in _result)
                    _devices.Add(_device);
            }
        }
    }
}
