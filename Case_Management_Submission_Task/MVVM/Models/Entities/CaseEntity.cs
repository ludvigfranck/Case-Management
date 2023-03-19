using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Case_Management_Submission_Task.MVVM.Models.Entities
{
    internal class CaseEntity
    {
        [Key, Column(Order = 0)]
        public Guid CustomerId { get; set; }

        [Key, Column(Order = 1)]
        public int DeviceId { get; set; }

        [Key, Column(Order = 2)]
        public Guid CaseId { get; set; } = Guid.NewGuid();


        [StringLength(200)]
        public string Description { get; set; } = null!;
        public string CaseStatus { get; set; } = null!;
        public DateTime Time { get; set; }
        
        public CustomerDeviceEntity CustomerDevice { get; set; } = null!;


        public static implicit operator CaseEntity(CaseModel caseModel)
        {
            return new CaseEntity
            {
                CaseId = caseModel.CaseId,
                Description = caseModel.CaseDescription,
                CaseStatus = caseModel.CaseStatus,
                Time = caseModel.Time
            };
        }

        public static implicit operator CaseModel(CaseEntity caseEntity)
        {
            return new CaseEntity
            {
                CaseId = caseEntity.CaseId,
                Description = caseEntity.Description,
                CaseStatus = caseEntity.CaseStatus,
                Time = caseEntity.Time
            };
        }
    }
}
