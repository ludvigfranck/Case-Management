using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Case_Management_Submission_Task.MVVM.Models.Entities
{
    [Index(nameof(Email), IsUnique = true)]
    internal class CustomerEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [StringLength(50)]
        public string FirstName { get; set; } = null!;

        [StringLength(50)]
        public string LastName { get; set; } = null!;

        [StringLength(100)]
        public string Email { get; set; } = null!;

        [Column(TypeName = "char(13)")]
        public string? PhoneNumber { get; set; }


        public int AddressId { get; set; }
        
        [ForeignKey("AddressId")]
        public AddressEntity Address { get; set; } = null!;

        public ICollection<DeviceEntity> Devices { get; set; } = new HashSet<DeviceEntity>();


        public static implicit operator CustomerEntity(CustomerModel customerModel)
        {
            return new CustomerEntity
            {
                Id = customerModel.Id,
                FirstName = customerModel.FirstName,
                LastName = customerModel.LastName,
                Email = customerModel.Email,
                PhoneNumber = customerModel.PhoneNumber
            };
        }

        public static implicit operator CustomerModel(CustomerEntity customerEntity)
        {
            return new CustomerModel
            {
                Id = customerEntity.Id,
                FirstName = customerEntity.FirstName,
                LastName = customerEntity.LastName,
                Email = customerEntity.Email,
                PhoneNumber = customerEntity.PhoneNumber
            };
        }
    }
}
