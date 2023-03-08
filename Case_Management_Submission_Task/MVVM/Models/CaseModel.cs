using System;

namespace Case_Management_Submission_Task.MVVM.Models
{
    internal class CaseModel
    {
        public int Id { get; set; }
        public string Description { get; set; } = null!;
        public string CaseStatus { get; set; } = null!;
        public DateTime Time { get; set; } = DateTime.Now;
    }
}
