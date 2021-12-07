using Microsoft.EntityFrameworkCore;
using way.Modules.Movies.Entities;
using way.Modules.Rooms.Entities;
using way.Modules.Sessions.Entities;
using way.Modules.Users.Entities;

namespace way.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<User> Users { get; set; }


        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=cinema_db;Username=print_way;Password=awake");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>();
            modelBuilder.Entity<Room>();
            modelBuilder.Entity<Session>();
            modelBuilder.Entity<User>();
        }
    }
}
