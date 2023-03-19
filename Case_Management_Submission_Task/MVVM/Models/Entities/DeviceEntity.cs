using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Case_Management_Submission_Task.MVVM.Models.Entities
{
    internal class DeviceEntity
    {
        [Key]
        public int Id { get; set; }

        public Guid ArticleNumber { get; set; } = new Guid();
        
        [StringLength(20)]
        public string DeviceName { get; set; } = null!;
        
        [StringLength(50)]
        public string DeviceDescription { get; set; } = null!;
        
        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        [NotMapped]
        public bool IsReadOnly { get; set; }

        public ICollection<CustomerEntity> Customers { get; set; } = new HashSet<CustomerEntity>();

        public static implicit operator DeviceEntity(DeviceModel deviceModel)
        {
            return new DeviceEntity
            {
                Id = deviceModel.Id,
                ArticleNumber = deviceModel.ArticleNumber,
                DeviceName = deviceModel.DeviceName,
                DeviceDescription = deviceModel.DeviceDescription,
                Price = deviceModel.Price
            };
        }

        public static implicit operator DeviceModel(DeviceEntity deviceEntity)
        {
            return new DeviceModel
            {
                Id = deviceEntity.Id,
                ArticleNumber = deviceEntity.ArticleNumber,
                DeviceName = deviceEntity.DeviceName,
                DeviceDescription = deviceEntity.DeviceDescription,
                Price = deviceEntity.Price
            };
        }
    }
}
