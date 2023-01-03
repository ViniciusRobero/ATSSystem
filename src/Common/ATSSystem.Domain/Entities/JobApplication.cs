using System;

namespace ATSSystem.Domain.Entities
{
    public class JobApplication
    {
        public int Id { get; set; }
        public int JobId { get; set; }
        public int CandidateId { get; set; }
        public DateTime CreateAt { get; set; }
        public bool Active { get; set; }
    }
}
