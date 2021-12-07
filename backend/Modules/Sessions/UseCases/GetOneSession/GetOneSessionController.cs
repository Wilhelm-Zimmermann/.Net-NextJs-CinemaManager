using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using way.Modules.Sessions.Entities;
using way.Modules.Sessions.Repositories;

namespace way.Modules.Sessions.UseCases.GetOneSession
{
    [ApiController]
    [Route("sessions")]
    public class GetOneSessionController : ControllerBase
    {
        private readonly GetOneSessionService _service;

        public GetOneSessionController(ISessionsRepository repository)
        {
            _service = new GetOneSessionService(repository);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Session>> GetSessionsAsync(int id)
        {
            try
            {
                var session = await _service.GetSessionByIdAsync(id);

                return StatusCode(200, session);
            }catch(Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }
    }
}
