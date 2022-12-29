using ATSSystem.Domain.Entities;

namespace ATSSystem.Domain.Event
{
    public class CandidateCreatedEvent
    {
        public CandidateCreatedEvent(Candidate candidate)
        {
            Candidate = candidate;
        }

        public Candidate Candidate { get; }
    }
}
