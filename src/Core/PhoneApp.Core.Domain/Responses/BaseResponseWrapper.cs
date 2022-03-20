namespace PhoneApp.Core.Domain.Responses
{
    public class BaseResponseWrapper
    {
        public BaseResponseWrapper(int statusCode)
        {
            StatusCode = statusCode;
        }
        public BaseResponseWrapper(int statusCode, string errorCode = null, IEnumerable<string> errors = null)
        {
            StatusCode = statusCode;
            ErrorCode = errorCode;
            Errors = errors;
        }
        public BaseResponseWrapper(int statusCode, string errorCode = null, string errorMessage = null)
        {
            StatusCode = statusCode;
            ErrorCode = errorCode;
            Errors = new string[] { errorMessage };
        }

        public bool Success => Errors == null || !Errors.Any();
        public int StatusCode { get; set; }
        public string ErrorCode { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
