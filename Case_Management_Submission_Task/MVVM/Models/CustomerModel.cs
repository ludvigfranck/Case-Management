using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Case_Management_Submission_Task.MVVM.Models
{
    internal class CustomerModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set;} = null!;
        public string Email { get; set; } = null!;
        public string? PhoneNumber { get; set; } = null!;
        public string DisplayName => $"{FirstName} {LastName}";

        public string StreetName { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
        public string City { get; set; } = null!;

        public List<DeviceModel> Devices { get; set; } = null!;
    }
}
