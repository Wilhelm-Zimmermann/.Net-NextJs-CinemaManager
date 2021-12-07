using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using way.Modules.Sessions.Entities;

namespace way.Modules.Movies.Entities
{
    public class Movie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int? Id { get; set; } 

        public string Title { get; set; }

        public string Description { get; set; }

        public TimeSpan Duration { get; set; }

        public string Image { get; set; }

        public ICollection<Session> Sessions { get; set; } = new List<Session>();
    }
}
