using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Case_Management_Submission_Task.MVVM.Models.Entities
{
    internal class DeviceEntity
    {
        [Key]
        public Guid ArticleNumber { get; set; } = new Guid();
        
        [StringLength(20)]
        public string DeviceName { get; set; } = null!;
        
        [StringLength(50)]
        public string DeviceDescription { get; set; } = null!;
        
        [Column(TypeName = "money")]
        public decimal Price { get; set; }
        
        public Guid CustomerId { get; set; }
        
        [ForeignKey("CustomerId")]
        public CustomerEntity Customer { get; set; } = null!;
    }
}
