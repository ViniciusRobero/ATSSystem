using System;
using System.Collections.Generic;
using System.Text;

namespace ATSSystem.Domain.Entities
{
    public  class Job
    {
        public int Id { get; set; }

        public string JobTitle { get; set; }

        public string JobDiscription { get; set; }

        public string Seniority { get; set; }

        public decimal Salary { get; set; }

        public string Curriculum { get; set; }

    }
}
