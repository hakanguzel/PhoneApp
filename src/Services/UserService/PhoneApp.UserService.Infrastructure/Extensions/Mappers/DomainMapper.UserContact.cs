using PhoneApp.Core.Domain.Base;
using PhoneApp.Core.Domain.Entities;
using PhoneApp.Core.Domain.Utility;
using PhoneApp.UserService.Domain.Users.Contacts;

namespace PhoneApp.UserService.Infrastructure.Extensions.Mappers
{
    public static partial class DomainMapper
    {
        #region UserContact to UserContactEntity 
        public static UserContactEntity Map(this UserContact domain)
        {
            return new UserContactEntity()
            {
                Id = domain.Id,
                Content = domain.Content,
                InformationType = domain.InformationType.ToInt(),
                Status = domain.Status.ToInt(),
                CreatedAt = domain.CreatedAt,
                ModifiedAt = domain.ModifiedAt
            };
        }
        #endregion
        #region UserContactEntity to UserContact 
        public static UserContact Map(this UserContactEntity domain)
        {
            return UserContact.Map(
                        domain.Id,
                        domain.Status.ToEnum<BaseStatus>(),
                        domain.Content,
                        domain.InformationType.ToEnum<InformationType>(),
                        domain.CreatedAt,
                        domain.ModifiedAt);
        }
        #endregion
    }
}
