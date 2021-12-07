using way.Modules.Movies.Entities;
using way.Modules.Rooms.Entities;
using way.Modules.Sessions.Entities;

namespace way.Modules.Sessions.Repositories
{
    public interface ISessionsRepository
    {
        Task<IEnumerable<Session>> GetSessionsAsync();
        Task<Session> GetSessionByIdAsync(int id);
        Task CreateSessionAsync(Session session);
        Task DeleteSessionAsync(Session session);
        Task<IEnumerable<Session>> GetSessionsByRoomIdAsync(int roomId); 
    }
}
