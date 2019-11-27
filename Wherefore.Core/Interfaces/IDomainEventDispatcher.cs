using Wherefore.Core.SharedKernel;

namespace Wherefore.Core.Interfaces
{
    public interface IDomainEventDispatcher
    {
        void Dispatch(BaseDomainEvent domainEvent);
    }
}