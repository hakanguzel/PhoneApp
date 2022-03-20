namespace PhoneApp.Core.Domain.Entities.Base
{
    public class BaseActivityEntity : BaseEntity
    {
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
