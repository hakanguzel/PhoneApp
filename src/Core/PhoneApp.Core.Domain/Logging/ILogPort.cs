namespace PhoneApp.Core.Domain.Logging
{
    public interface ILogPort
    {
        void LogError(string message);
        void LogError(string message, Exception ex);
        void LogWarn(string message);
        void LogWarn(string message, Exception ex);
        void LogInfo(string message);
        void LogInfo(string message, Exception ex);
    }
}
