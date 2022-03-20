using Moq;
using MoqAssist.Core;
using PhoneApp.Core.Domain.Entities;
using PhoneApp.Core.Infrastructure;
using PhoneApp.ReportService.Infrastructure.Reports;
using PhoneApp.ReportService.UnitTests.Base;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PhoneApp.ReportService.UnitTests.Infrastructure.Reports
{
    public class ReportCommandDataAdapterTests : TestBase
    {
        private readonly MoqAssist<ReportCommandDataAdapter> _dataAdapterMoqAssist;
        private readonly ReportCommandDataAdapter _dataAdapter;

        private readonly Mock<IAppDbContext> _mockAppDbContext;
        public ReportCommandDataAdapterTests()
        {
            _dataAdapterMoqAssist = MoqAssist<ReportCommandDataAdapter>.Construct(new DefaultMockDictionary());
            _dataAdapter = _dataAdapterMoqAssist.GetConstructors().FirstOrDefault();

            _mockAppDbContext = _dataAdapterMoqAssist.GetMock<IAppDbContext>();
        }
        [Fact]
        public async Task CreateAsync_Should_Return_Response_When_Success()
        {
            var reportId = 1;
            var report = GetGeneratedActiveAndWaitingReport();
            _mockAppDbContext.Setup(q => q.Reports.AddAsync(It.IsAny<ReportEntity>(), CancellationToken.None));

            _mockAppDbContext.Setup(q => q.SaveChangesAsync(CancellationToken.None))
                .ReturnsAsync(reportId);

            var actual = await _dataAdapter.CreateAsync(report);
            Assert.Equal(reportId, actual);
        }
        [Fact]
        public async Task CreateAsync_Throws_Fail_When_Report_Not_Created()
        {
            var reportId = 0;
            var report = GetGeneratedActiveAndWaitingReport();
            _mockAppDbContext.Setup(q => q.Reports.AddAsync(It.IsAny<ReportEntity>(), CancellationToken.None));

            _mockAppDbContext.Setup(q => q.SaveChangesAsync(CancellationToken.None))
                .ReturnsAsync(reportId);

            var actual = await _dataAdapter.CreateAsync(report);
            Assert.Equal(reportId, actual);
        }

        [Fact]
        public async Task SaveAsync_Should_Return_Response_When_Success()
        {
            var reportId = 1;
            var report = GetGeneratedActiveAndWaitingReport();
            _mockAppDbContext.Setup(q => q.Reports.Update(It.IsAny<ReportEntity>()));

            _mockAppDbContext.Setup(q => q.SaveChangesAsync(CancellationToken.None))
                .ReturnsAsync(reportId);

            var actual = await _dataAdapter.SaveAsync(report);
            Assert.True(actual);
        }
        [Fact]
        public async Task SaveAsync_Throws_Fail_When_Report_Not_Saved()
        {
            var reportId = 0;
            var report = GetGeneratedActiveAndWaitingReport();
            _mockAppDbContext.Setup(q => q.Reports.Update(It.IsAny<ReportEntity>()));

            _mockAppDbContext.Setup(q => q.SaveChangesAsync(CancellationToken.None))
                .ReturnsAsync(reportId);

            var actual = await _dataAdapter.SaveAsync(report);
            Assert.False(actual);
        }
    }
}
