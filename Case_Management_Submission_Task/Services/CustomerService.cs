using Case_Management_Submission_Task.Contexts;
using Case_Management_Submission_Task.MVVM.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Case_Management_Submission_Task.Services
{
    internal class CustomerService
    {
        private static DataContext _context = new DataContext();
        public CustomerService()
        {

        }
        public async Task<IEnumerable<CustomerModel>> GetAllAsync()
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
    }
}
