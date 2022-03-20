namespace PhoneApp.Core.Domain.Base
{
    public class BaseActivityDomain<TKey> : BaseDomain<TKey>
    {
        public DateTime CreatedAt { get; protected set; }
        public DateTime ModifiedAt { get; protected set; }

        public void SetCreatedAt(DateTime createdAt) => CreatedAt = createdAt;
        public void SetModifiedAt(DateTime modifiedAt) => ModifiedAt = modifiedAt;
    }
}
