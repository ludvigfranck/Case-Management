using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Case_Management_Submission_Task.MVVM.Models.Entities
{
    internal class CaseEntity
    {
        [Key]
        public int Id { get; set; }

        [StringLength(200)]
        public string Description { get; set; } = null!;
        public string CaseStatus { get; set; } = null!;
        public DateTime Time { get; set; } = DateTime.Now;
        
        public Guid DeviceId { get; set; }

        [ForeignKey("DeviceId")]
        public DeviceEntity Device { get; set; } = null!;
    }
}
