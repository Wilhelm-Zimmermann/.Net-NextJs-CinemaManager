using way.Modules.Users.Entities;
using way.Modules.Users.Repositories;
using way.Utils;

namespace way.Modules.Users.UseCases
{
    public class AuthenticationService
    {
        private readonly IUsersRepository _repository;

        public AuthenticationService(IUsersRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> GetUserByEmailAsync(string email, string password)
        {
            var user = await _repository.GetUserByEmailAsync(email);

            if (user is null) throw new Exception("Email/Password might be invalid");

            if (password != user.Password) throw new Exception("Email/Password might be invalid");

            var token = TokenService.GenerateToken(user);

            return token;
        }
    }
}
