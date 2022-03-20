using PhoneApp.Core.Domain.Abstractions;
using PhoneApp.Core.Domain.Base;
using PhoneApp.Core.Domain.Utility;
using PhoneApp.ReportService.Domain.Reports.Exceptions;

namespace PhoneApp.ReportService.Domain.Reports
{
    public sealed class Report : BaseActivityDomain<int>, IAggregateRoot
    {
        public ReportStatus ReportStatus { get; private set; }
        public string Location { get; private set; }
        public int UserCount { get; private set; }
        public int PhoneCount { get; private set; }

        public void SetUserCount(int userCount)
        {
            AppRule.NotNegative<ReportDomainException>(userCount, ReportDomainExceptionMessages.USER_COUNT_CANNOT_BE_NEGATIVE);
            UserCount = userCount;
        }
        public void SetPhoneCount(int phoneCount)
        {
            AppRule.NotNegative<ReportDomainException>(phoneCount, ReportDomainExceptionMessages.PHONE_COUNT_CANNOT_BE_NEGATIVE);
            PhoneCount = phoneCount;
        }

        public void MarkAsWaiting() => ReportStatus = ReportStatus.Waiting;
        public void MarkAsDone() => ReportStatus = ReportStatus.Done;
        public void MarkAsFail() => ReportStatus = ReportStatus.Fail;
        public static Report Default() => new();
        public static Report CreateNew(
            string location,
            ReportStatus reportStatus,
            BaseStatus status)
        {
            AppRule.NotNullOrEmpty<ReportDomainException>(location, ReportDomainExceptionMessages.LOCATION_CANNOT_BE_NULL_OR_EMPTY);
            return new Report()
            {
                Location = location,
                ReportStatus = reportStatus,
                Status = status,
                UserCount = default(int),
                PhoneCount = default(int)
            };
        }
        public static Report Map(
            int id,
            BaseStatus status,
            ReportStatus reportStatus,
            string location,
            int userCount,
            int phoneCount,
            DateTime createdAt,
            DateTime modifiedAt)
        {
            return new Report()
            {
                Id = id,
                Status = status,
                ReportStatus = reportStatus,
                Location = location,
                UserCount = userCount,
                PhoneCount = phoneCount,
                CreatedAt = createdAt,
                ModifiedAt = modifiedAt
            };
        }
    }
}
