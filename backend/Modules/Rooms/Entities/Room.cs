using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using way.Modules.Sessions.Entities;

namespace way.Modules.Rooms.Entities
{
    public class Room
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int SeatsQuantity { get; set; }

        public ICollection<Session> Sessions { get; set; } = new List<Session>();
    }
}
