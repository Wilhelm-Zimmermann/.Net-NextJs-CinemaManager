using way.Modules.Sessions.Entities;
using way.Modules.Sessions.Repositories;

namespace way.Modules.Sessions.UseCases.GetSessions
{
    public class GetSessionsService
    {
        private readonly ISessionsRepository _repository;

        public GetSessionsService(ISessionsRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Session>> GetSessionsAsync()
        {
            return await _repository.GetSessionsAsync();
        }
    }
}
