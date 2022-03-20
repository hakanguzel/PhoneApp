using PhoneApp.Core.Domain.Base;

namespace PhoneApp.Core.Domain.Abstractions
{
    public interface IDomain : IReadOnlyDomain
    {
        void MarkAsActive();
        void MarkAsPassive();
        void MarkAsDeleted();

        void SetStatus(BaseStatus status);
    }
}
