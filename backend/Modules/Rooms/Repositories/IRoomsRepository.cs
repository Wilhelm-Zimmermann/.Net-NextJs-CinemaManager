using way.Modules.Rooms.Entities;

namespace way.Modules.Rooms.Repositories
{
    public interface IRoomsRepository
    {
        Task<IEnumerable<Room>> GetRoomsAsync();
        Task<Room> GetRoomByIdAsync(int id);
    }
}
