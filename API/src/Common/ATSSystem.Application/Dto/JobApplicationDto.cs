using System;
using System.Collections.Generic;
using ATSSystem.Domain.Entities;
using Mapster;

namespace ATSSystem.Application.Dto
{
    public class JobApplicationDto
    {
        public int Id { get; set; }
        public int JobId { get; set; }
        public int CandidateId { get; set; }
        public int CreateAt { get; set; }
        public bool Active { get; set; }
    }
}
