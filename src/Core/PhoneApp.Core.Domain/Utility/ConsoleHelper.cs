namespace PhoneApp.Core.Domain.Utility
{
    public static class ConsoleHelper
    {

        public static void Success(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);

            Console.ResetColor();
        }
        public static void Success(string message, Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message, ex);

            Console.ResetColor();
        }

        public static void Warn(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(message);

            Console.ResetColor();
        }
        public static void Warn(string message, Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(message, ex);

            Console.ResetColor();
        }
        public static void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);

            Console.ResetColor();
        }
        public static void Error(string message, Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message, ex);

            Console.ResetColor();
        }
    }
}
