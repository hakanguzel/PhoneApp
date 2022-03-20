using PhoneApp.Core.Application.Abstractions;

namespace PhoneApp.UserService.Domain.Users
{
    public interface IUserCommandDataPort : ICommandDataPort
    {
        Task<int> CreateAsync(User user);
        Task<bool> SaveAsync(User user);
    }
}
