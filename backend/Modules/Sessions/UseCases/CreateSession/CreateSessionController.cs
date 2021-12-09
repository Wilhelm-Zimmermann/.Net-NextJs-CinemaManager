using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using way.Modules.Movies.Repositories;
using way.Modules.Rooms.Repositories;
using way.Modules.Sessions.Dtos;
using way.Modules.Sessions.Repositories;

namespace way.Modules.Sessions.UseCases.CreateSession
{
    [ApiController]
    [Route("sessions")]
    public class CreateSessionController : ControllerBase
    {
        private readonly CreateSessionService _service;

        public CreateSessionController(ISessionsRepository sessionsRepository, IRoomsRepository roomsRepository, IMoviesRepository moviesRepository)
        {
            _service = new CreateSessionService(sessionsRepository, roomsRepository, moviesRepository);
        }

        [HttpPost]
        // [Authorize(Roles = "Admin")]
        public async Task<ActionResult> CreateSessionAsync(CreateSessionDto sessionDto)
        {
            try
            {
                await _service.CreateSessionAsync(sessionDto);
                return StatusCode(201);
            }catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }
    }
}
