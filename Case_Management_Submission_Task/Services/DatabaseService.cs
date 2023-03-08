using Case_Management_Submission_Task.Contexts;
using Case_Management_Submission_Task.MVVM.Models.Entities;
using Case_Management_Submission_Task.MVVM.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Case_Management_Submission_Task.Services
{
    internal class DatabaseService
    {
        private static DataContext _context = new DataContext();
        public DatabaseService()
        {
            var address = new AddressEntity
            {
                StreetName = "Slottsgatan 12",
                PostalCode = "703 61",
                City = "Örebro"
            };

            var customer = new CustomerEntity
            {
                FirstName = "Ludde",
                LastName = "Franck",
                Email = "ludde@gmail.com",
                PhoneNumber = "072-325 97 07",
                Address = address
            };

            _context.Add(address);
            _context.Add(customer);
            _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CustomerModel>> GetAllAsync()
        {
            var _customers = new List<CustomerModel>();

            foreach (var _customer in await _context.Customers.ToListAsync())
            {
                _customers.Add(new CustomerModel
                {
                    Id = _customer.Id,
                    FirstName = _customer.FirstName,
                    LastName = _customer.LastName,
                    Email = _customer.Email,
                    PhoneNumber = _customer.PhoneNumber
                });
            }

            return _customers;
        }
    }
}
