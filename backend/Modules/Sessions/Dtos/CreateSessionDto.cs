namespace way.Modules.Sessions.Dtos
{
    public class CreateSessionDto
    {
        public string Start { get; set; }

        public decimal TicketValue { get; set; }

        public int RoomId { get; set; }

        public int MovieId { get; set; }
    }
}
