namespace PhoneApp.Core.Infrastructure.Environments
{
    public class CapSettings
    {
        public CapRabbitMqSettings CapRabbitMqSettings { get; set; }
        public QueueSettings ReportQueueSettings { get; set; }
    }
    public class CapRabbitMqSettings
    {
        public string Protocol { get; set; }
        public string Hostname { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
    public class QueueSettings
    {
        public string ConnectionStrings { get; set; }
        public string Exchange { get; set; }
    }
}
