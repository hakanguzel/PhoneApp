using PhoneApp.Core.Domain.Base;
using PhoneApp.ReportService.Domain.Reports;
using PhoneApp.ReportService.Domain.Reports.Exceptions;
using System;
using Xunit;

namespace PhoneApp.ReportService.UnitTests.Domain
{
    public class ReportTests
    {
        private readonly Report _report;
        #region Constructor
        public ReportTests()
        {
            _report = Report.CreateNew(location: "Adana", ReportStatus.Waiting, BaseStatus.Active);
        }
        #endregion
        #region CreateNew Method Tests

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void CreateNew_Should_ThrowException_When_LocationIsNullOrEmpty(string location)
        {
            var exception = Assert.Throws<ReportDomainException>(() =>
                Report.CreateNew(location: location, ReportStatus.Waiting, BaseStatus.Active));

            Assert.Equal(ReportDomainExceptionMessages.LOCATION_CANNOT_BE_NULL_OR_EMPTY, exception.DisplayMessage);
        }
        [Fact]
        public void CreateNew_Should_Be_Successful()
        {
            var report = Report.CreateNew(location: "Adana", ReportStatus.Waiting, BaseStatus.Active);

            Assert.True(report.Status == BaseStatus.Active);
        }
        #endregion
        #region Map Method Tests
        [Fact]
        public void Map_Should_Be_Successful()
        {
            var id = 1;
            var status = BaseStatus.Active;
            var reportStatus = ReportStatus.Waiting;
            var location = "Adana";
            var userCount = 1;
            var phoneCount = 2;
            var dateTime = DateTime.Now;

            var report = Report.Map(
                id: id,
                status: status,
                reportStatus: reportStatus,
                location: location,
                userCount: userCount,
                phoneCount: phoneCount,
                createdAt: dateTime,
                modifiedAt: dateTime
                );

            Assert.Equal(id, report.Id);
            Assert.Equal(status, report.Status);
            Assert.Equal(reportStatus, report.ReportStatus);
            Assert.Equal(location, report.Location);
            Assert.Equal(userCount, report.UserCount);
            Assert.Equal(phoneCount, report.PhoneCount);
            Assert.Equal(dateTime, report.CreatedAt);
            Assert.Equal(dateTime, report.ModifiedAt);
        }
        #endregion
        #region Default Method Tests
        [Fact]
        public void Default_Should_Be_Successful()
        {
            var report = Report.Default();
            Assert.False(report.IsExist());
        }
        #endregion
        #region Set User Count Tests
        [Fact]
        public void SetUserCount_Should_Throw_Exception_When_UserCountIsNegative()
        {
            var userCount = -1;
            var exception = Assert.Throws<ReportDomainException>(() => _report.SetUserCount(userCount));
            Assert.Equal(ReportDomainExceptionMessages.USER_COUNT_CANNOT_BE_NEGATIVE, exception.DisplayMessage);
        }

        [Fact]
        public void SetUserCount_Should_Be_Successful()
        {
            var userCount = 1;
            _report.SetUserCount(userCount);

            Assert.Equal(userCount, _report.UserCount);
        }
        #endregion
        #region Set Phone Count Tests
        [Fact]
        public void SetPhoneCount_Should_Throw_Exception_When_PhoneCountIsNegative()
        {
            int phoneCount = -1;
            var exception = Assert.Throws<ReportDomainException>(() => _report.SetPhoneCount(phoneCount));
            Assert.Equal(ReportDomainExceptionMessages.PHONE_COUNT_CANNOT_BE_NEGATIVE, exception.DisplayMessage);
        }

        [Fact]
        public void SetPhoneCount_Should_Be_Successful()
        {
            var phoneCount = 1;
            _report.SetPhoneCount(phoneCount);

            Assert.Equal(phoneCount, _report.PhoneCount);
        }
        #endregion

        #region Mark As Waiting Tests
        [Fact]
        public void MarkAsWaiting_Should_Be_Successful()
        {
            _report.MarkAsWaiting();
            Assert.True(_report.ReportStatus == ReportStatus.Waiting);
        }
        #endregion
        #region Mark As Done Tests
        [Fact]
        public void MarkAsDone_Should_Be_Successful()
        {
            _report.MarkAsDone();
            Assert.True(_report.ReportStatus == ReportStatus.Done);
        }
        #endregion
        #region Mark As Fail Tests
        [Fact]
        public void MarkAsFail_Should_Be_Successful()
        {
            _report.MarkAsFail();
            Assert.True(_report.ReportStatus == ReportStatus.Fail);
        }
        #endregion
    }
}
