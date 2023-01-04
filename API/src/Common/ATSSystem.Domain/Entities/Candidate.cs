using System;

namespace ATSSystem.Domain.Entities
{
    public class Candidate
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public string Phone { get; set; }

        public string Curriculum { get; set; }

    }
}
