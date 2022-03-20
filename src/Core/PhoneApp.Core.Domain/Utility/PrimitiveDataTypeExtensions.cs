namespace PhoneApp.Core.Domain.Utility
{
    public static class PrimitiveDataTypeExtensions
    {
        public static bool IsNegative(this int value) => value < 0;
        public static bool IsNegativeOrZero(this int value) => value <= 0;
    }
}
