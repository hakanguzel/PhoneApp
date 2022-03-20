namespace PhoneApp.Core.Domain.Utility
{
    public static class EventHelper
    {
        public static Uri BuildRabbitMQUri(string protocol, string username, string password, string hostname, int port)
        {
            return new Uri(protocol + "://" + username + ":" + password + "@" + hostname + ":" + port);
        }
    }
}
