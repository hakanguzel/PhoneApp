using PhoneApp.Core.Domain.Base;
using PhoneApp.Core.Domain.Entities;
using PhoneApp.Core.Domain.Utility;
using PhoneApp.UserService.Domain.Users.Contacts;
using PhoneApp.UserService.Infrastructure.Extensions.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace PhoneApp.UserService.UnitTests.Infrastructure.MapperTests
{
    public class UserContactTests
    {
        [Fact]
        public void Map_Should_Return_ValidEntityObject()
        {
            var entity = 
                new UserContactEntity
                {
                    Content ="Adana",
                    InformationType= 3,
                    Status = BaseStatus.Active.ToInt(),
                    UserId = 1,
                };

          
            var domain = entity.Map();

            Assert.Equal(domain.Id, entity.Id);
            Assert.Equal(domain.Content, entity.Content);
            Assert.Equal(domain.InformationType.ToInt(), entity.InformationType);
            Assert.Equal(domain.Status.ToInt(), entity.Status);
            Assert.Equal(domain.CreatedAt, entity.CreatedAt);
            Assert.Equal(domain.ModifiedAt, entity.ModifiedAt);
            Assert.Equal(domain.Status.ToInt(), entity.Status);
        }
        [Fact]
        public void Map_Should_Return_ValidDomainObject()
        {
            var domain = UserContact.CreateNew("Adana", InformationType.Address);
            var entity = domain.Map();

            Assert.Equal(domain.Content, entity.Content);
            Assert.Equal(domain.InformationType.ToInt(), entity.InformationType);
            Assert.Equal(domain.CreatedAt, entity.CreatedAt);
            Assert.Equal(domain.ModifiedAt, entity.ModifiedAt);
            Assert.Equal(domain.Status.ToInt(), entity.Status);
        }
    }
}
