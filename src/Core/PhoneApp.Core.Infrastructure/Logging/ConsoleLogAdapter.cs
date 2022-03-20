using PhoneApp.Core.Domain.Logging;
using PhoneApp.Core.Domain.Utility;

namespace PhoneApp.Core.Infrastructure.Logging
{
    internal class ConsoleLogAdapter : ILogPort
    {
        public ConsoleLogAdapter()
        {
        }

        public void LogError(string message) => ConsoleHelper.Error(message);
        public void LogError(string message, Exception ex) => ConsoleHelper.Error(message, ex);

        public void LogInfo(string message) => ConsoleHelper.Success(message);
        public void LogInfo(string message, Exception ex) => ConsoleHelper.Success(message, ex);

        public void LogWarn(string message) => ConsoleHelper.Warn(message);
        public void LogWarn(string message, Exception ex) => ConsoleHelper.Warn(message, ex);
    }
}
