using MediatR;
using Microsoft.AspNetCore.Mvc;
using PhoneApp.ReportService.API.Controllers.Base;
using PhoneApp.ReportService.Application.Reports.Commands.CreateReportRequest;
using PhoneApp.ReportService.Application.Reports.Commands.GenerateReport;
using PhoneApp.ReportService.Application.Reports.Queries.GetReport;
using PhoneApp.ReportService.Application.Reports.Queries.ListReports;

namespace PhoneApp.ReportService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : BaseApiController
    {
        private readonly IMediator _mediator;
        public ReportsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> ListReports()
        {
            var filter = new ListReportsQuery();
            var response = await _mediator.Send(filter);
            return Ok(response);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetReport([FromRoute] int id)
        {
            var request = new GetReportQuery(id);
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> CreateReport(CreateReportRequestCommand createReportCommand)
        {
            var response = await _mediator.Send(createReportCommand);
            return Ok(response);
        }
        [HttpPost("generate")]
        public async Task<IActionResult> GenerateReport(GenerateReportCommand generateReportCommand)
        {
            var response = await _mediator.Send(generateReportCommand);
            return Ok(response);
        }
    }
}
