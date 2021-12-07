using way.Modules.Sessions.Entities;
using way.Modules.Sessions.Repositories;

namespace way.Modules.Sessions.UseCases.GetOneSession
{
    public class GetOneSessionService
    {
        private readonly ISessionsRepository _repository;

        public GetOneSessionService(ISessionsRepository repository)
        {
            _repository = repository;
        }

        public async Task<Session> GetSessionByIdAsync(int id)
        {
            var session = await _repository.GetSessionByIdAsync(id);

            if (session is null)
            {
                throw new Exception("This session does not exists");
            }

            return session;
        }
    }
}
