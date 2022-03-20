using PhoneApp.Core.Domain.Base;
using PhoneApp.UserService.Domain.Users;
using PhoneApp.UserService.Domain.Users.Contacts;
using System;
using System.Collections.Generic;

namespace PhoneApp.UserService.UnitTests.Base
{
    public class TestBase
    {
        public static User GetGeneratedActiveUser()
        {
            var contacts = new List<UserContact>()
            {
                UserContact.Map(
                    id : 1,
                    status : BaseStatus.Active,
                    content: "Mersin",
                    informationType: InformationType.Address,
                    createdAt: DateTime.Now,
                    modifiedAt: DateTime.Now)
            };

            return User.Map(
                id: 1,
                status: BaseStatus.Active,
                name: "Hakan",
                surname: "GÜZEL",
                companyName: "Farmazon",
                createdAt: DateTime.Now,
                modifiedAt: DateTime.Now,
                contacts: contacts
                );
        }
        public static User GetGeneratedDeletedUser()
        {
            var contacts = new List<UserContact>()
            {
                UserContact.Map(
                    id : 1,
                    status : BaseStatus.Active,
                    content: "Mersin",
                    informationType: InformationType.Address,
                    createdAt: DateTime.Now,
                    modifiedAt: DateTime.Now)
            };

            return User.Map(
                id: 1,
                status: BaseStatus.Deleted,
                name: "Hakan",
                surname: "GÜZEL",
                companyName: "Farmazon",
                createdAt: DateTime.Now,
                modifiedAt: DateTime.Now,
                contacts: contacts
                );
        }
    }
}
