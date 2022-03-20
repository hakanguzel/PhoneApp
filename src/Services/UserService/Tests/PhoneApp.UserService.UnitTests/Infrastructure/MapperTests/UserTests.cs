using PhoneApp.Core.Domain.Entities;
using System;
using Xunit;
using PhoneApp.Core.Domain.Base;
using PhoneApp.Core.Domain.Utility;
using PhoneApp.UserService.Infrastructure.Extensions.Mappers;
using PhoneApp.UserService.Domain.Users;
using System.Collections.Generic;
using PhoneApp.UserService.Domain.Users.Contacts;

namespace PhoneApp.UserService.UnitTests.Infrastructure.MapperTests
{
    public class UserTests
    {
        [Fact]
        public void Map_Should_Return_DefaultObject_When_DomainIsNull()
        {
            var entity = default(UserEntity);
            var domain = entity.Map();

            Assert.False(domain.IsExist());
        }
        [Fact]
        public void Map_Should_Return_ValidEntityObject()
        {

            var contacts = new List<UserContactEntity>
            {
                new UserContactEntity
                {
                    Content ="Adana",
                    InformationType= 3,
                    Status = BaseStatus.Active.ToInt(),
                    UserId = 1,
                }
            };

            UserEntity entity = new UserEntity
            {
                Id = 1,
                Name = "Hakan",
                Surname = "GÜZEL",
                CompanyName = "Farmazon",
                Contacts = contacts,
                ModifiedAt = new DateTime(2022, 01, 03),
                CreatedAt = new DateTime(2022, 01, 03),
                Status = BaseStatus.Active.ToInt()
            };
            var domain = entity.Map();

            Assert.Equal(domain.Id, entity.Id);
            Assert.Equal(domain.Name, entity.Name);
            Assert.Equal(domain.Surname, entity.Surname);
            Assert.Equal(domain.CompanyName, entity.CompanyName);
            Assert.Equal(domain.CreatedAt, entity.CreatedAt);
            Assert.Equal(domain.ModifiedAt, entity.ModifiedAt);
            Assert.Equal(domain.Status.ToInt(), entity.Status);
            Assert.Equal(domain.Contacts.Count, entity.Contacts.Count);
        }
        [Fact]
        public void Map_Should_Contact_Null_Return_ValidEntityObject()
        {
            UserEntity entity = new UserEntity
            {
                Id = 1,
                Name = "Hakan",
                Surname = "GÜZEL",
                CompanyName = "Farmazon",
                Contacts = null,
                ModifiedAt = new DateTime(2022, 01, 03),
                CreatedAt = new DateTime(2022, 01, 03),
                Status = BaseStatus.Active.ToInt()
            };
            var domain = entity.Map();

            Assert.Equal(domain.Id, entity.Id);
            Assert.Equal(domain.Name, entity.Name);
            Assert.Equal(domain.Surname, entity.Surname);
            Assert.Equal(domain.CompanyName, entity.CompanyName);
            Assert.Equal(domain.CreatedAt, entity.CreatedAt);
            Assert.Equal(domain.ModifiedAt, entity.ModifiedAt);
            Assert.Equal(domain.Status.ToInt(), entity.Status);
        }
        [Fact]
        public void Map_Should_Return_ValidDomainObject()
        {
            var domain = User.CreateNew("Hakan", "GÜZEL", "Farmazon", BaseStatus.Active);
            domain.AddContact("Adana", InformationType.Address);
            var entity = domain.Map();

            Assert.Equal(domain.Name, entity.Name);
            Assert.Equal(domain.Surname, entity.Surname);
            Assert.Equal(domain.CompanyName, entity.CompanyName);
            Assert.Equal(domain.CreatedAt, entity.CreatedAt);
            Assert.Equal(domain.ModifiedAt, entity.ModifiedAt);
            Assert.Equal(domain.Status.ToInt(), entity.Status);
            Assert.Equal(domain.Contacts.Count, entity.Contacts.Count);
        }
        [Fact]
        public void Map_Should_Contact_Null_Return_ValidDomainObject()
        {
            var domain = User.CreateNew("Hakan", "GÜZEL", "Farmazon", BaseStatus.Active);
            var entity = domain.Map();

            Assert.Equal(domain.Name, entity.Name);
            Assert.Equal(domain.Surname, entity.Surname);
            Assert.Equal(domain.CompanyName, entity.CompanyName);
            Assert.Equal(domain.CreatedAt, entity.CreatedAt);
            Assert.Equal(domain.ModifiedAt, entity.ModifiedAt);
            Assert.Equal(domain.Status.ToInt(), entity.Status);
            Assert.Equal(domain.Contacts.Count, entity.Contacts.Count);
        }
    }
}
