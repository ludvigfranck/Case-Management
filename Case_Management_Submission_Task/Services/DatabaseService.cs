using Case_Management_Submission_Task.Contexts;
using Case_Management_Submission_Task.MVVM.Models.Entities;
using Case_Management_Submission_Task.MVVM.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows;
using System.Linq;
using System;

namespace Case_Management_Submission_Task.Services
{
    internal class DatabaseService
    {
        private static DataContext _context = new DataContext();
        public DatabaseService()
        {
        }

        public async Task<IEnumerable<CustomerModel>> GetAllCustomersAsync()
        {
            try
            {
                var _customers = new ObservableCollection<CustomerModel>();

                foreach (var _customer in await _context.Customers.Include(x => x.Address).ToListAsync())
                {
                    _customers.Add(new CustomerModel
                    {
                        Id = _customer.Id,
                        FirstName = _customer.FirstName,
                        LastName = _customer.LastName,
                        Email = _customer.Email,
                        PhoneNumber = _customer.PhoneNumber,
                        StreetName = _customer.Address.StreetName,
                        PostalCode = _customer.Address.PostalCode,
                        City = _customer.Address.City
                    });
                }

                return _customers;
            }
            catch { return null!; }
        }

        public async Task<IEnumerable<DeviceModel>> GetSpecificCustomerDevices(CustomerModel _customerModel)
        {
            var _customerEntity = await _context.Customers.Include(c => c.Devices).FirstOrDefaultAsync(c => c.Id == _customerModel.Id);

            var _devices = new ObservableCollection<DeviceModel>();

            if(_customerEntity != null) 
            { 
                foreach(var _device in _customerEntity.Devices) 
                {
                    _devices.Add(new DeviceModel
                    {
                        Id = _device.Id,
                        ArticleNumber = _device.ArticleNumber,
                        DeviceName = _device.DeviceName,
                        DeviceDescription = _device.DeviceDescription,
                        Price = _device.Price
                    });
                }
            }

            return _devices;
        }

        public async Task<IEnumerable<CaseModel>> GetCasesForCustomerWithCustomerIdAsync(Guid customerId)
        {
            var _cases = new ObservableCollection<CaseModel>();

            var customerDevices = await _context.CustomersDevices
            .Include(cd => cd.Cases)
            .Where(cd => cd.CustomerId == customerId)
            .ToListAsync();

            var _result = new List<CaseEntity>();
            foreach (var device in customerDevices)
            {
                _result.AddRange(device.Cases);
            }

            foreach (var _case in _result)
            {
                _cases.Add(new CaseModel
                {
                    CaseId = _case.CaseId,
                    CaseDescription = _case.Description,
                    CaseStatus = _case.Status,
                    Time = _case.Time,
                    CaseComment = _case.Comment
                });
            }

            return _cases;
        }

        public async Task<IEnumerable<CaseModel>> GetCasesForCustomerWithDeviceIdAsync(int deviceId)
        {
            var _cases = new ObservableCollection<CaseModel>();

            var customerDevices = _context.CustomersDevices
            .Where(cd => cd.DeviceId == deviceId)
            .Select(cd => cd.DeviceId)
            .ToList();

            var _result = await _context.Cases
                .Where(c => customerDevices.Contains(c.DeviceId))
                .ToListAsync();

            foreach (var _case in _result)
                _cases.Add(new CaseModel
                {
                    CaseId = _case.CaseId,
                    CaseDescription = _case.Description,
                    CaseStatus = _case.Status,
                    Time = _case.Time,
                    CaseComment= _case.Comment
                });

            return _cases;
        }

        public async Task<IEnumerable<DeviceModel>> GetAllDevicesAsync()
        {
            try
            {
                var _devices = new ObservableCollection<DeviceModel>();

                foreach (var _device in await _context.Devices.ToListAsync())
                {
                    _devices.Add(new DeviceModel
                    {
                        Id = _device.Id,
                        ArticleNumber = _device.ArticleNumber,
                        DeviceName = _device.DeviceName,
                        DeviceDescription = _device.DeviceDescription,
                        Price = _device.Price
                    });
                }

                return _devices;
            }
            catch { return null!; }
        }

        public async Task SaveCustomerAsync(CustomerModel customerModel, ObservableCollection<DeviceModel> deviceModels)
        {
            if (customerModel != null && deviceModels.Any())
            {
                var _customerEntity = new CustomerEntity
                {
                    FirstName = customerModel.FirstName,
                    LastName = customerModel.LastName,
                    Email = customerModel.Email,
                    PhoneNumber = customerModel.PhoneNumber,
                    Address = new AddressEntity
                    {
                        StreetName = customerModel.StreetName,
                        PostalCode = customerModel.PostalCode,
                        City = customerModel.City
                    }
                };

                foreach(var _deviceModel in deviceModels)
                {
                    if(_deviceModel.IsSelected)
                    {
                        var _deviceEntity = await _context.Devices.FindAsync(_deviceModel.Id);

                        var _customerDeviceEntity = new CustomerDeviceEntity
                        {
                            Customer = _customerEntity,
                            Device = _deviceEntity!
                        };

                        _customerEntity.Devices.Add(_deviceEntity!);
                        _context.CustomersDevices.Add(_customerDeviceEntity);
                    }
                }

                _context.Customers.Add(_customerEntity);
                await _context.SaveChangesAsync();
            }
            else
            {
                MessageBox.Show("Something went wrong, try again...");
                return;
            }
                
        }

        public async Task CreateCaseAsync(CaseModel caseModel, CustomerModel customerModel, DeviceModel deviceModel)
        {
            if(deviceModel.DeviceName != null && caseModel.CaseDescription != null)
            {
                var _customerDevice = await _context.CustomersDevices
                .SingleOrDefaultAsync(cd => cd.CustomerId == customerModel.Id && cd.DeviceId == deviceModel.Id);

                var _existingCases = await GetCasesForCustomerWithDeviceIdAsync(deviceModel.Id);

                if (_existingCases.Any())
                {
                    var _result = MessageBox.Show($"A case for {deviceModel.ArticleNumber} already exists, do you want to add another case?", "Case already exists", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (_result == MessageBoxResult.No)
                        return;
                }

                var caseEntity = new CaseEntity
                {
                    Description = caseModel.CaseDescription,
                    Status = "Pending",
                    Time = DateTime.Now,
                    Comment = "No current comments",
                    CustomerDevice = _customerDevice!
                };

                _customerDevice!.Cases.Add(caseEntity);

                await _context.SaveChangesAsync();
            }
            else
            {
                MessageBox.Show("Invalid input parameters!");
                return;
            }
        }

        public async Task UpdateCaseAsync(CaseModel caseModel, string status, string comment)
        {
            var _caseEntity = await _context.Cases.FirstOrDefaultAsync(x => x.CaseId == caseModel.CaseId);

            if (_caseEntity != null)
            {
                if(status != null)
                    _caseEntity.Status = status;
                else _caseEntity.Status = caseModel.CaseStatus;

                if (comment != null)
                    _caseEntity.Comment = comment;
                else _caseEntity.Comment = caseModel.CaseComment;
            } 

            await _context.SaveChangesAsync();
        }

        public async Task RemoveCaseAsync(CaseModel caseModel)
        {
            var _caseEntity = await _context.Cases.FirstOrDefaultAsync(x => x.CaseId == caseModel.CaseId);
            _context.Cases.Remove(_caseEntity!);

            MessageBox.Show($"Removed Case: {_caseEntity!.CaseId}");

            await _context.SaveChangesAsync();
        }
    }
}
