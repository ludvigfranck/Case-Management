using System;

namespace Case_Management_Submission_Task.MVVM.Models
{
    internal class DeviceModel
    {
        public int Id { get; set; }
        public Guid ArticleNumber { get; set; }
        public string DeviceName { get; set; } = null!;
        public string DeviceDescription { get; set; } = null!;
        public decimal Price { get; set; }
        public bool IsSelected { get; set; }

        public CustomerModel? Customer { get; set; }
    }
}
