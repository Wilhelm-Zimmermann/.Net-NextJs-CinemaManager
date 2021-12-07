using way.Database;
using Microsoft.EntityFrameworkCore;
using way.Modules.Rooms.Entities;

namespace way.Modules.Rooms.Repositories
{
    public class RoomsRepository : IRoomsRepository
    {
        private readonly DatabaseContext _context;

        public RoomsRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Room> GetRoomByIdAsync(int id)
        {
            return await _context.Rooms.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Room>> GetRoomsAsync()
        {
            return await _context.Rooms.ToListAsync();
        }
    }
}
