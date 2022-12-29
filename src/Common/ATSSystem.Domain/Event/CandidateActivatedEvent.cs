using ATSSystem.Domain.Entities;

namespace ATSSystem.Domain.Event
{
    public class CandidateActivatedEvent
    {
        public CandidateActivatedEvent(Candidate candidate)
        {
            Candidate = candidate;
        }

        public Candidate Candidate { get; }
    }
}
