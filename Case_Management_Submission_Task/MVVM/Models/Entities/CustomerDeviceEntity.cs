using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Case_Management_Submission_Task.MVVM.Models.Entities
{
    internal class CustomerDeviceEntity
    {
        [Key, Column(Order = 0)]
        public Guid CustomerId { get; set; }

        [Key, Column(Order = 1)]
        public int DeviceId { get; set; }

        public CustomerEntity Customer { get; set; } = null!;
        public DeviceEntity Device { get; set; } = null!;

        public ICollection<CaseEntity> Cases { get; set; } = new HashSet<CaseEntity>();
    }
}
