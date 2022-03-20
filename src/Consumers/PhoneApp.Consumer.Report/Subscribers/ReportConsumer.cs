using DotNetCore.CAP;
using PhoneApp.Core.Application.Events;
using PhoneApp.Core.Infrastructure.Environments;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace PhoneApp.Consumer.Report.Subscribers
{
    public class ReportConsumer : IReportSubscriber
    {
        private readonly HttpClient _httpClient;
        private readonly ApplicationSettings _applicationSettings;
        public ReportConsumer(HttpClient httpClient,
            ApplicationSettings applicationSettings)
        {
            _applicationSettings = applicationSettings;
            _httpClient = httpClient;
        }

        [CapSubscribe("report.event", Group = "send_report_queue")]
        public async Task ConsumeAsync(ReportCreatedEvent @event, [FromCap] CapHeader header)
        {
            var url = "http://localhost:5000/reportservice/generate";
            var requestModel = new RequestModel(@event.ReportId);
            JsonContent content = JsonContent.Create(requestModel);

            var responseMessage = await _httpClient.PostAsync(url, content);
            if (!responseMessage.IsSuccessStatusCode)
                throw new Exception($"Status Code: {responseMessage.StatusCode} Content: {responseMessage.Content}");

        }
        private class RequestModel
        {
            public RequestModel(int reportId)
            {
                ReportId = reportId;
            }
            public int ReportId { get; set; }
        }

    }
}
