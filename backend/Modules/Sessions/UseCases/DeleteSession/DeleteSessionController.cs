using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using way.Modules.Sessions.Repositories;

namespace way.Modules.Sessions.UseCases.DeleteSession
{
    [ApiController]
    [Route("sessions")]
    public class DeleteSessionController : ControllerBase
    {
        private readonly DeleteSessionService _service;

        public DeleteSessionController(ISessionsRepository repository)
        {
            _service = new DeleteSessionService(repository);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteSectionAsycn(int id)
        {
            try
            {
                await _service.DeleteSessionAsync(id);

                return StatusCode(200, "Session Deleted");
            } catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }
    }
}
