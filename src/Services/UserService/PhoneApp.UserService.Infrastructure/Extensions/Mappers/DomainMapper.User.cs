using PhoneApp.Core.Domain.Base;
using PhoneApp.Core.Domain.Entities;
using PhoneApp.Core.Domain.Utility;
using PhoneApp.UserService.Domain.Users;
using PhoneApp.UserService.Domain.Users.Contacts;

namespace PhoneApp.UserService.Infrastructure.Extensions.Mappers
{
    public static partial class DomainMapper
    {
        #region User to UserEntity 
        public static UserEntity Map(this User domain)
        {
            var contacts = domain.Contacts != null ? domain.Contacts.Select(x => x.Map()).ToList() : null;

            return new UserEntity()
            {
                Id = domain.Id,
                Name = domain.Name,
                Surname = domain.Surname,
                CompanyName = domain.CompanyName,
                Status = domain.Status.ToInt(),
                CreatedAt = domain.CreatedAt,
                ModifiedAt = domain.ModifiedAt,
                Contacts = contacts
            };
        }
        #endregion
        #region UserEntity to User 
        public static User Map(this UserEntity entity)
        {
            if (entity == null)
                return User.Default();

            var contacts = entity.Contacts != null ? entity.Contacts.Select(x => x.Map()).ToList() : new List<UserContact>();

            return User.Map(entity.Id,
                entity.Status.ToEnum<BaseStatus>(),
                entity.Name,
                entity.Surname,
                entity.CompanyName,
                entity.CreatedAt,
                entity.ModifiedAt,
                contacts);
        }
        #endregion
    }
}
