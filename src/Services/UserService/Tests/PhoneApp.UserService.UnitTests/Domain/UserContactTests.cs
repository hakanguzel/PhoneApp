using PhoneApp.Core.Domain.Base;
using PhoneApp.UserService.Domain.Users;
using PhoneApp.UserService.Domain.Users.Contacts;
using PhoneApp.UserService.Domain.Users.Exceptions;
using System;
using System.Collections.Generic;
using Xunit;


namespace PhoneApp.UserService.UnitTests.Domain
{
    public class UserContactTests
    {
        private readonly UserContact _userContact;

        #region Constructor
        public UserContactTests()
        {
            _userContact = UserContact.Map(
                    id: 1,
                    status: BaseStatus.Active,
                    content: "Mersin",
                    informationType: InformationType.Address,
                    createdAt: DateTime.Now,
                    modifiedAt: DateTime.Now);
        }
        #endregion

        #region CreateNew Method Tests
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void CreateNew_Should_ThrowException_When_ContentIsNullOrEmpty(string content)
        {
            var exception = Assert.Throws<UserDomainException>(() =>
                UserContact.CreateNew(
                    content: content,
                    informationType: InformationType.Phone));

            Assert.Equal(UserDomainExceptionMessages.CONTENT_CANNOT_BE_NULL_OR_EMPTY, exception.DisplayMessage);
        }
        [Fact]
        public void CreateNew_Should_Be_Successful()
        {
            var content = "Adana";
            var informationType = InformationType.Address;
            var contact = UserContact.CreateNew(
                    content: content,
                    informationType: informationType);

            Assert.True(contact.Status == BaseStatus.Active);
            Assert.True(contact.Content == content);
            Assert.True(contact.InformationType == informationType);
        }
        #endregion

        #region Map Method Tests

        [Fact]
        public void Map_Should_Be_Successful()
        {
            var id = 1;
            var status = BaseStatus.Active;
            var dateTime = DateTime.Now;
            var content = "Adana";
            var informationType = InformationType.Address;

            var contact = UserContact.Map(
                id: id,
                status: status,
                content: content,
                informationType: informationType,
                createdAt: dateTime,
                modifiedAt: dateTime
                );

            Assert.Equal(id, contact.Id);
            Assert.Equal(status, contact.Status);
            Assert.Equal(content, contact.Content);
            Assert.Equal(informationType, contact.InformationType);
            Assert.Equal(dateTime, contact.CreatedAt);
            Assert.Equal(dateTime, contact.ModifiedAt);
        }
        #endregion



    }
}
