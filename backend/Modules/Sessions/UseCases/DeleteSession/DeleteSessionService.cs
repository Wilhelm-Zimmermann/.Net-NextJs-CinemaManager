using way.Modules.Sessions.Repositories;

namespace way.Modules.Sessions.UseCases.DeleteSession
{
    public class DeleteSessionService
    {
        private readonly ISessionsRepository _repository;

        public DeleteSessionService(ISessionsRepository repository)
        {
            _repository = repository;
        }

        public async Task DeleteSessionAsync(int id)
        {
            var session = await _repository.GetSessionByIdAsync(id);

            if(session is null)
            {
                throw new Exception("Session does not exists");
            }
            var now = DateTime.Now;

            if(session.Start.Subtract(now).Days < 10)
            {
                throw new Exception("Cannot remove this section.Its only possible to remove sessions which Start date is greater than 9 days");
            }

            await _repository.DeleteSessionAsync(session);  
        } 
    }
}
