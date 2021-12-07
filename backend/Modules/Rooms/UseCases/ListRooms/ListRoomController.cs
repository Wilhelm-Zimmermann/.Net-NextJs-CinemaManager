using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using way.Modules.Rooms.Entities;
using way.Modules.Rooms.Repositories;

namespace way.Modules.Rooms.UseCases.ListRooms
{
    [ApiController]
    [Route("rooms")]
    public class ListRoomController : ControllerBase
    {
        private readonly ListRoomService _service;

        public ListRoomController(IRoomsRepository repository)
        {
            _service = new ListRoomService(repository);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<Room>>> GetRoomsAsync()
        {
            var rooms = await _service.GetRoomsAsync();
            return StatusCode(200, rooms);
        }
    }
}
