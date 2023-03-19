using Case_Management_Submission_Task.Helpers;
using Case_Management_Submission_Task.MVVM.Models;
using Case_Management_Submission_Task.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Case_Management_Submission_Task.MVVM.ViewModels
{
    internal class CreateCustomerViewModel : ObservableObject
    {
        private readonly NavigationStore _navigationStore;
        private readonly DatabaseService _databaseService;

        private CustomerModel _customer;
        private ObservableCollection<DeviceModel> _selectedDevices;
        private ObservableCollection<DeviceModel> _devices;

        public CreateCustomerViewModel(NavigationStore navigationStore, DatabaseService databaseService)
        {
            _navigationStore = navigationStore;
            _databaseService = databaseService;
            
            LoadDevicesAsync();

            _customer = new CustomerModel();
            _devices = new ObservableCollection<DeviceModel>();
            _selectedDevices = new ObservableCollection<DeviceModel>();

            CreateCustomerCommand = new NavigateCommand<CustomersViewModel>(_navigationStore, () =>
            {
                Task.Run(async () =>
                {
                    await CreateCustomerAsync();
                }).Wait();
                return new CustomersViewModel(_navigationStore, _databaseService);
            });
        }

        public CustomerModel Customer
        {
            get { return _customer; }
            set { _customer = value; }
        }

        public ObservableCollection<DeviceModel> SelectedDevices
        {
            get { return _selectedDevices; }
            set { _selectedDevices = value; }
        }

        public ObservableCollection<DeviceModel> Devices
        {
            get { return _devices; }
            set { _devices = value; }
        }

        public ICommand CreateCustomerCommand { get; }

        private async void LoadDevicesAsync()
        {
            var _result = await _databaseService.GetAllDevicesAsync();
            if (_result.Any())
            {
                foreach (var _device in _result)
                    _devices.Add(_device);
            }
            else
                MessageBox.Show("No current Devices in database...");
        }

        private async Task CreateCustomerAsync()
        {
            if (_customer.FirstName != null && _customer.LastName != null && _customer.Email != null && _customer.PhoneNumber != null && _customer.StreetName != null && _customer.PostalCode != null && _customer.City != null)
            {
                foreach (var _device in _devices)
                {
                    if (_device.IsSelected)
                        _selectedDevices.Add(_device);
                }

                await _databaseService.SaveCustomerAsync(_customer, _selectedDevices);
            }
            else
                MessageBox.Show("All input fields must have an input!");
        }
    }
}
