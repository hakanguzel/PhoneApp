namespace PhoneApp.Core.Domain.Modelling
{
    public interface IReadOnlyDomain
    {
        bool IsExist();
        bool IsActive();
        bool IsPassive();
        bool IsDeleted();
    }
}
