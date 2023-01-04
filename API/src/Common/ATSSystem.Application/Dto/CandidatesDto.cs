using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ATSSystem.Domain.Entities;
using Mapster;

namespace ATSSystem.Application.Dto
{
    public class CandidatesDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Curriculum { get; set; }
    }
}
