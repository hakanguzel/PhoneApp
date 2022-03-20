using Microsoft.AspNetCore.Http;

namespace PhoneApp.Core.Domain.Responses
{
    public class ResponseWrapper<T> : BaseResponseWrapper
    {
        public ResponseWrapper() : base(StatusCodes.Status200OK) { }
        public ResponseWrapper(T result) : base(StatusCodes.Status200OK) => Result = result;
        public ResponseWrapper(int statusCode, string errorCode, IEnumerable<string> errors) : base(statusCode, errorCode, errors) { }
        public ResponseWrapper(int statusCode, string errorCode, string errorMessage) : base(statusCode, errorCode, errorMessage) { }

        public T Result { get; set; }
    }
}
