using PhoneApp.Core.Domain.Base;
using PhoneApp.Core.Domain.Entities;
using PhoneApp.Core.Domain.Utility;
using PhoneApp.ReportService.Domain.Reports;
using PhoneApp.ReportService.Infrastructure.Extensions.Mappers;
using System;
using Xunit;

namespace PhoneApp.ReportService.UnitTests.Infrastructure.MapperTests
{
    public class ReportTests
    {
        [Fact]
        public void Map_Should_Return_DefaultObject_When_DomainIsNull()
        {
            var entity = default(ReportEntity);
            var domain = entity.Map();

            Assert.False(domain.IsExist());
        }
        [Fact]
        public void Map_Should_Return_ValidEntityObject()
        {
            ReportEntity entity = new ReportEntity
            {
                Id = 1,
                PhoneCount = 12,
                UserCount = 51,
                Location = "Adana",
                ReportStatus = ReportStatus.Fail.ToInt(),
                ModifiedAt = new DateTime(2022, 01, 03),
                CreatedAt = new DateTime(2022, 01, 03),
                Status = BaseStatus.Active.ToInt()
            };
            var domain = entity.Map();

            Assert.Equal(domain.Id, entity.Id);
            Assert.Equal(domain.PhoneCount, entity.PhoneCount);
            Assert.Equal(domain.Location, entity.Location);
            Assert.Equal(domain.Location, entity.Location);
            Assert.Equal(domain.ReportStatus.ToInt(), entity.ReportStatus);
            Assert.Equal(domain.CreatedAt, entity.CreatedAt);
            Assert.Equal(domain.Status.ToInt(), entity.Status);
        }
        [Fact]
        public void Map_Should_Return_ValidDomainObject()
        {
            var domain = Report.CreateNew("Adana", ReportStatus.Waiting, BaseStatus.Active);
            var entity = domain.Map();

            Assert.Equal(domain.Location, entity.Location);
            Assert.Equal(domain.ReportStatus.ToInt(), entity.ReportStatus);
            Assert.Equal(domain.Status.ToInt(), entity.Status);
        }
    }
}
