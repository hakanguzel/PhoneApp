using PhoneApp.Core.Domain.Abstractions;

namespace PhoneApp.Core.Domain.Base
{
    public class BaseDomain<TKey> : IDomain
    {
        public TKey Id { get; protected set; }
        public BaseStatus Status { get; protected set; } = BaseStatus.Active;

        public void MarkAsActive() => Status = BaseStatus.Active;
        public void MarkAsPassive() => Status = BaseStatus.Passive;
        public void MarkAsDeleted() => Status = BaseStatus.Deleted;
        public void SetStatus(BaseStatus status) => Status = status;

        public bool IsExist()
        {
            if (Id is int)
                return (int)(object)Id > 0 && Status != BaseStatus.Deleted;
            else if (Id is string)
                return Id.ToString() != null && Status != BaseStatus.Deleted;
            else if (Id is object)
                return Id != null && Id.ToString() != null && Status != BaseStatus.Deleted;

            return false;
        }
        public bool IsActive() => Status == BaseStatus.Active;
        public bool IsPassive() => Status == BaseStatus.Passive;
        public bool IsDeleted() => Status == BaseStatus.Deleted;
    }
}
