using System;
using System.Collections.Generic;
using ATSSystem.Domain.Entities;
using Mapster;

namespace ATSSystem.Application.Dto
{
    public class CandidatesDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Document { get; set; }

        public DateTime BirthDate { get; set; }

        public string Occupation { get; set; }

        public string Seniority { get; set; }
    }
}
