namespace PhoneApp.Core.Domain.Utility
{
    public static class EnumConverter
    {
        public static int ToInt(this Enum en)
        {
            return Convert.ToInt32(en);
        }

        public static T ToEnum<T>(this int id) where T : Enum
        {
            T foo = (T)Enum.ToObject(typeof(T), id);
            return foo;
        }
    }
}
