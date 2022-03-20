using Microsoft.AspNetCore.Mvc;
using PhoneApp.Core.Domain.Responses;

namespace PhoneApp.ReportService.API.Controllers.Base
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BaseApiController : ControllerBase
    {
        public OkObjectResult Ok<T>(T data) => new OkObjectResult(new ResponseWrapper<T>(data));
    }
}
