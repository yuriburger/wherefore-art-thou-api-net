using Wherefore.Core.Entities;
using Wherefore.Core.SharedKernel;

namespace Wherefore.Core.Events
{
    public class CandidateMatchedEvent : BaseDomainEvent
    {
        public Candidate MatchedCandidate { get; set; }

        public CandidateMatchedEvent(Candidate matchedCandidate)
        {
            MatchedCandidate = matchedCandidate;
        }
    }
}