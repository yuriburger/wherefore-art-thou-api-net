using Wherefore.Core.SharedKernel;

namespace Wherefore.Core.Interfaces
{
    public interface IHandle<T> where T : BaseDomainEvent
    {
        void Handle(T domainEvent);
    }
}