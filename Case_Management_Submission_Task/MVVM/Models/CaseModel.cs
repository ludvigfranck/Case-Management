using System;

namespace Case_Management_Submission_Task.MVVM.Models
{
    internal class CaseModel
    {
        public Guid CaseId { get; set; }
        public string CaseDescription { get; set; } = null!;
        public string CaseStatus { get; set; } = null!;
        public DateTime Time { get; set; }
        public string CaseComment { get; set; } = null!;
    }
}
