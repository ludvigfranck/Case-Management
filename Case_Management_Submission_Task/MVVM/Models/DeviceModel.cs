using System;

namespace Case_Management_Submission_Task.MVVM.Models
{
    internal class DeviceModel
    {
        public Guid Id { get; set; }
        public string DeviceName { get; set; } = null!;
        public string DeviceDescription { get; set; } = null!;
        public decimal Price { get; set; }
    }
}
