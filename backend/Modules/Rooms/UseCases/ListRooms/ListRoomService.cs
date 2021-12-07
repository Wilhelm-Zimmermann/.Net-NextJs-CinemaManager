using way.Modules.Rooms.Entities;
using way.Modules.Rooms.Repositories;

namespace way.Modules.Rooms.UseCases.ListRooms
{
    public class ListRoomService
    {
        private readonly IRoomsRepository _repository;

        public ListRoomService(IRoomsRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Room>> GetRoomsAsync()
        {
            return await _repository.GetRoomsAsync();
        }
    }
}
