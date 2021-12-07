using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using way.Modules.Movies.Entities;
using way.Modules.Rooms.Entities;

namespace way.Modules.Sessions.Entities
{
    public class Session
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int? Id { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public decimal TicketValue { get; set; }

        public int RoomId { get; set; }
        public int MovieId { get; set; }

        [ForeignKey("MovieId")]
        public virtual Movie Movie { get; set; }

        [ForeignKey("RoomId")]
        public virtual Room Room { get; set; }

    }
}
