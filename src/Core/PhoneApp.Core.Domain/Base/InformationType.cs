namespace PhoneApp.Core.Domain.Base
{
    public enum InformationType
    {
        Phone = 1,
        Email = 2,
        Address = 3
    }
    public class InformationTypeStrings
    {
        public const string PHONE = "phone";
        public const string EMAIL = "email";
        public const string ADDRESS = "address";
    }
    public static class InformationTypeExtensions
    {
        public static InformationType ToInformationType(this string status)
        {
            return status switch
            {
                InformationTypeStrings.PHONE => InformationType.Phone,
                InformationTypeStrings.EMAIL => InformationType.Email,
                InformationTypeStrings.ADDRESS => InformationType.Address
            };
        }
    }
}
