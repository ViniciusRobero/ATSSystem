using System;

namespace ATSSystem.Domain.Entities
{
    public class Candidate
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Document { get; set; }

        public DateTime BirthDate { get; set; }

        public string Occupation { get; set; }

        public string Seniority { get; set; }
    }
}
