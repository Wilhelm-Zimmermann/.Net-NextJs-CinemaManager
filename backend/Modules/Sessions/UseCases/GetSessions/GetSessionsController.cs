using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using way.Modules.Sessions.Entities;
using way.Modules.Sessions.Repositories;

namespace way.Modules.Sessions.UseCases.GetSessions
{
    [ApiController]
    [Route("sessions")]
    public class GetSessionsController : ControllerBase
    {
        private readonly GetSessionsService _service;

        public GetSessionsController(ISessionsRepository repository)
        {
            _service = new GetSessionsService(repository);
        }

        [HttpGet]
        // [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<Session>>> GetSessionsAsync()
        {
            var sessions = await _service.GetSessionsAsync();

            return StatusCode(200, sessions);
        }
    }
}
