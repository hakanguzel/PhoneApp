using PhoneApp.Core.Domain.Base;
using PhoneApp.UserService.Domain.Users;
using PhoneApp.UserService.Domain.Users.Contacts;
using PhoneApp.UserService.Domain.Users.Exceptions;
using System;
using System.Collections.Generic;
using Xunit;

namespace PhoneApp.UserService.UnitTests.Domain
{
    public class UserTests
    {
        private readonly User _user;

        #region Constructor
        public UserTests()
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

            _user = User.Map(
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
        #endregion

        #region CreateNew Method Tests
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void CreateNew_Should_ThrowException_When_NameIsNullOrEmpty(string name)
        {
            var exception = Assert.Throws<UserDomainException>(() =>
                User.CreateNew(
                    name: name,
                    surname: "GÜZEL",
                    companyName: "Farmazon",
                    status: BaseStatus.Active));

            Assert.Equal(UserDomainExceptionMessages.NAME_CANNOT_BE_NULL_OR_EMPTY, exception.DisplayMessage);
        }
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void CreateNew_Should_ThrowException_When_SurnameIsNullOrEmpty(string surname)
        {
            var exception = Assert.Throws<UserDomainException>(() =>
                User.CreateNew(
                    name: "Hakan",
                    surname: surname,
                    companyName: "Farmazon",
                    status: BaseStatus.Active));

            Assert.Equal(UserDomainExceptionMessages.SURNAME_CANNOT_BE_NULL_OR_EMPTY, exception.DisplayMessage);
        }
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void CreateNew_Should_ThrowException_When_CompanyNameIsNullOrEmpty(string companyName)
        {
            var exception = Assert.Throws<UserDomainException>(() =>
                User.CreateNew(
                    name: "Hakan",
                    surname: "GÜZEL",
                    companyName: companyName,
                    status: BaseStatus.Active));

            Assert.Equal(UserDomainExceptionMessages.COMPANY_NAME_CANNOT_BE_NULL_OR_EMPTY, exception.DisplayMessage);
        }
        [Fact]
        public void CreateNew_Should_Be_Successful()
        {
            var name = "Hakan";
            var surname = "GÜZEL";
            var companyName = "Farmazon";
            var user = User.CreateNew(
                    name: name,
                    surname: surname,
                    companyName: companyName,
                    status: BaseStatus.Active);

            Assert.True(user.Status == BaseStatus.Active);
            Assert.True(user.Name == name);
            Assert.True(user.Surname == surname);
            Assert.True(user.CompanyName == companyName);
        }
        #endregion

        #region Map Method Tests

        [Fact]
        public void Map_Should_Be_Successful()
        {
            var id = 1;
            var status = BaseStatus.Active;
            var dateTime = DateTime.Now;
            var name = "Hakan";
            var surname = "GÜZEL";
            var companyName = "Farmazon";
            var contacts = new List<UserContact>();

            var user = User.Map(
                id: id,
                status: status,
                name: name,
                surname: surname,
                companyName: companyName,
                createdAt: dateTime,
                modifiedAt: dateTime,
                contacts: contacts
                );

            Assert.Equal(id, user.Id);
            Assert.Equal(status, user.Status);
            Assert.Equal(name, user.Name);
            Assert.Equal(surname, user.Surname);
            Assert.Equal(companyName, user.CompanyName);
            Assert.Equal(dateTime, user.CreatedAt);
            Assert.Equal(dateTime, user.ModifiedAt);
            Assert.Equal(contacts.Count, user.Contacts.Count);
        }
        #endregion

        #region Default Method Tests
        [Fact]
        public void Default_Should_Be_Successful()
        {
            var user = User.Default();
            Assert.False(user.IsExist());
        }
        #endregion

        #region Is Content Exists Tests
        [Fact]
        public void IsContentExists_Should_Return_True()
        {
            var location = "Adana";
            _user.AddContact(location, InformationType.Address);
            var result = _user.IsContentExists(location);
            Assert.True(result);
        }

        [Fact]
        public void IsContentExists_Should_Return_False()
        {
            var location = "Mersin";
            var result = _user.IsContentExists(location);
            Assert.True(result);
        }
        #endregion
        #region Is Content Exists Tests
        [Fact]
        public void IsContactExists_Should_Return_True()
        {
            var id = 1;
            var result = _user.IsContactExists(id);
            Assert.True(result);
        }

        [Fact]
        public void IsContactExists_Should_Return_False()
        {
            var id = 1;
            var result = _user.IsContactExists(id);
            Assert.True(result);
        }
        #endregion

        #region Add Contact Tests

        [Theory]
        [InlineData("02122121221", InformationType.Phone)]
        [InlineData("Adana", InformationType.Address)]
        [InlineData("test@test.com", InformationType.Email)]
        public void AddContact_Should_Throw_Exception_When_Content_Already_Exists(string content, InformationType informationType)
        {
            _user.AddContact(content, informationType);

            var exception = Assert.Throws<UserDomainException>(() => _user.AddContact(content, informationType));
            Assert.Equal(UserDomainExceptionMessages.CONTENT_ALREADY_EXISTS, exception.DisplayMessage);
        }

        [Theory]
        [InlineData("02122121221", InformationType.Phone)]
        [InlineData("Adana", InformationType.Address)]
        [InlineData("test@test.com", InformationType.Email)]
        public void AddContact_Should_Be_Successful(string content, InformationType informationType)
        {
            _user.AddContact(content, informationType);
            Assert.Contains(_user.Contacts, phone => phone.Content == content && phone.InformationType == informationType && phone.IsActive());
        }
        #endregion

        #region Delete Contact Tests

        [Fact]
        public void DeleteContact_Should_Throw_Exception_When_Contact_Not_Found()
        {
            var contentId = 87;
            var exception = Assert.Throws<UserDomainException>(() => _user.DeleteContact(contentId));
            Assert.Equal(UserDomainExceptionMessages.CONTENT_NOT_EXISTS, exception.DisplayMessage);
        }

        [Fact]
        public void DeleteContact_Should_Be_Successful()
        {
            var contentId = 1;
            _user.DeleteContact(contentId);
            Assert.Contains(_user.Contacts, phone => phone.IsDeleted());
        }
        #endregion

    }
}
