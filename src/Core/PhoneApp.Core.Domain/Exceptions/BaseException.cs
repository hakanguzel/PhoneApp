namespace PhoneApp.Core.Domain.Exceptions
{
    public abstract class BaseException : Exception
    {
        public abstract string ExceptionId { get; }
        public abstract string DisplayMessage { get; }
        public abstract string ExceptionContent { get; }
        public abstract int Status { get; }

        public BaseException() : base() { }
        public BaseException(string displayMessage) : base(displayMessage) { }
    }
}
