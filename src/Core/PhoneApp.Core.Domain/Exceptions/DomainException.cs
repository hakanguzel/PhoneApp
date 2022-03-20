namespace PhoneApp.Core.Domain.Exceptions
{
    public abstract class DomainException : BaseException
    {
        public override int Status => 500;
    }
}
