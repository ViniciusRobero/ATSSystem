using System;
using System.Collections.Generic;
using ATSSystem.Domain.Entities;
using Mapster;

namespace ATSSystem.Application.Dto
{
    public class JobsDto
    {
        public int Id { get; set; }

        public string JobTitle { get; set; }

        public string JobDiscription { get; set; }

        public string Seniority { get; set; }

        public decimal Salary { get; set; }
    }
}
