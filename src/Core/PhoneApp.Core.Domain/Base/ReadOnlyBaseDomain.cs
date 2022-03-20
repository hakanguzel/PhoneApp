using PhoneApp.Core.Domain.Modelling;

namespace PhoneApp.Core.Domain.Base
{
    public class ReadOnlyBaseDomain<TKey> : IReadOnlyDomain
    {
        public TKey Id { get; protected set; }
        public BaseStatus Status { get; protected set; } = BaseStatus.Active;
        public DateTime CreatedAt { get; protected set; }
        public DateTime ModifiedAt { get; protected set; }

        public bool IsActive() => Status == BaseStatus.Active;
        public bool IsPassive() => Status == BaseStatus.Passive;
        public bool IsDeleted() => Status == BaseStatus.Deleted;
        public bool IsExist()
        {
            if (Id is int)
                return (int)(object)Id > 0 && Status != BaseStatus.Deleted;
            else if (Id is string)
                return Id.ToString() != null && Status != BaseStatus.Deleted;

            return false;
        }
    }
}
