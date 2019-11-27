using Wherefore.Core.Interfaces;
using Wherefore.Core.SharedKernel;

namespace Wherefore.UnitTests
{
    public class NoOpDomainEventDispatcher : IDomainEventDispatcher
    {
        public void Dispatch(BaseDomainEvent domainEvent) { }
    }
}
