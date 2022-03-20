namespace PhoneApp.Core.Domain.Abstractions
{
    public interface IReadOnlyDomain
    {
        bool IsExist();
        bool IsActive();
        bool IsPassive();
        bool IsDeleted();
    }

}
