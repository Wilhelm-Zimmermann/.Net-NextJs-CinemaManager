using way.Modules.Movies.Entities;
using way.Modules.Movies.Repositories;
using way.Modules.Rooms.Entities;
using way.Modules.Rooms.Repositories;
using way.Modules.Sessions.Dtos;
using way.Modules.Sessions.Entities;
using way.Modules.Sessions.Repositories;

namespace way.Modules.Sessions.UseCases.CreateSession
{
    public class CreateSessionService
    {
        private readonly ISessionsRepository _sessionsRepository;
        private readonly IRoomsRepository _roomsRepository;
        private readonly IMoviesRepository _moviesRepository;

        public CreateSessionService(ISessionsRepository sessionsRepository, IRoomsRepository roomsRepository, IMoviesRepository moviesRepository)
        {
            _sessionsRepository = sessionsRepository;
            _roomsRepository = roomsRepository;
            _moviesRepository = moviesRepository;
        }

        public async Task CreateSessionAsync(CreateSessionDto sessionDto)
        {
            var movieExists = await _moviesRepository.GetMovieByIdAsync(sessionDto.MovieId);
            var roomExists = await _roomsRepository.GetRoomByIdAsync(sessionDto.RoomId);

            if(movieExists is null || roomExists is null)
            {
                throw new Exception("Movie/Room does not exists");
            }

            var roomIsAvailable = await _sessionsRepository.GetSessionsByRoomIdAsync(sessionDto.RoomId);
            var start = DateTime.Parse(sessionDto.Start).ToUniversalTime();
            var end = start.ToUniversalTime().Add(movieExists.Duration);
            var now = DateTime.Now;

            if(start < now)
            {
                throw new Exception("The date must be in the future");
            }

            foreach(var room in roomIsAvailable)
            {
                if(room.Start <= start && room.End >= start)
                {
                    throw new Exception("This room is already reserved to this time.Try to add another date and hour");
                }
            }


            Session session = new()
            {
                MovieId = sessionDto.MovieId,
                RoomId = sessionDto.RoomId,
                Start = start,
                End = end,
                TicketValue = sessionDto.TicketValue,
            };

            await _sessionsRepository.CreateSessionAsync(session);
        }
    }
}
