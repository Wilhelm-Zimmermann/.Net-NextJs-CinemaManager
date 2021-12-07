using way.Modules.Users.Entities;

namespace way.Modules.Users.Repositories
{
    public interface IUsersRepository
    {
        Task<User> GetUserByEmailAsync(string email);
        Task<User> GetUserByIdAsync(int id);
    }
}
