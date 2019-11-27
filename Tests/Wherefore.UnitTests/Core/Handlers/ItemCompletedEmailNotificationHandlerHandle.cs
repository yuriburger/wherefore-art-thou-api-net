using Wherefore.Core.Entities;
using Wherefore.Core.Events;
using Wherefore.Core.Services;
using System;
using Xunit;

namespace Wherefore.UnitTests.Core.Entities
{
    public class CandidateMatchedEmailNotificationHandlerHandle
    {
        [Fact]
        public void DoesNothingGivenEventInstance()
        {
            var handler = new CandidateMatchedEmailNotificationHandler();

            handler.Handle(new CandidateMatchedEvent(new Candidate()));
        }
    }
}
