namespace PhoneApp.Core.Domain.Exceptions
{
    public abstract class BusinessValidationException : BaseException
    {
        public override int Status => 500;
    }
}
