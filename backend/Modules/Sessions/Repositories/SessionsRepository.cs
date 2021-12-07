using way.Database;
using way.Modules.Movies.Entities;
using way.Modules.Rooms.Entities;
using way.Modules.Sessions.Entities;
using Microsoft.EntityFrameworkCore;

namespace way.Modules.Sessions.Repositories
{
    public class SessionsRepository : ISessionsRepository
    {
        private readonly DatabaseContext _context;

        public SessionsRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task CreateSessionAsync(Session session)
        {
            await _context.Sessions.AddAsync(session);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSessionAsync(Session session)
        {
            _context.Sessions.Attach(session);
            _context.Sessions.Remove(session);
            await _context.SaveChangesAsync();
        }

        public async Task<Session> GetSessionByIdAsync(int id)
        {
            return await _context.Sessions.FindAsync(id);
        }

        public async Task<IEnumerable<Session>> GetSessionsByRoomIdAsync(int roomId)
        {
            var sessions = await
                _context.Sessions.Where(x => x.RoomId == roomId)
                .ToListAsync();
            return sessions;
        }

        public async Task<IEnumerable<Session>> GetSessionsAsync()
        {
            return await _context.Sessions.ToListAsync();
        }
    }
}
