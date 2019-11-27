using Wherefore.Core.Events;
using Wherefore.Core.SharedKernel;
using System.Collections.Generic;

namespace Wherefore.Core.Entities
{
    public class Candidate : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public string Avatar { get; set; }

        public string Props { get; set; }

        public bool IsMatched { get; private set; }

        public void MarkMatched()
        {
            IsMatched = true;
            Events.Add(new CandidateMatchedEvent(this));
        }
    }
}
