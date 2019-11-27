using Wherefore.Core.Events;
using Wherefore.Core.Interfaces;

namespace Wherefore.Core.Services
{
    public class CandidateMatchedEmailNotificationHandler : IHandle<CandidateMatchedEvent>
    {
        public void Handle(CandidateMatchedEvent domainEvent)
        {
        }
    }
}
