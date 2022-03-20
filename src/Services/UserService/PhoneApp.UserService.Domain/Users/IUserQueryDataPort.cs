using PhoneApp.Core.Application.Abstractions;

namespace PhoneApp.UserService.Domain.Users
{
    public interface IUserQueryDataPort : IQueryDataPort
    {
        Task<List<User>> GetAsync();
        Task<User> GetAsync(int id);
        Task<User> GetContactAsync(int id);
    }
}
