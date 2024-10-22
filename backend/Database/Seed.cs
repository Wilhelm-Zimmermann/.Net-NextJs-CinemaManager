﻿using way.Modules.Movies.Entities;
using way.Modules.Rooms.Entities;
using way.Modules.Sessions.Entities;
using way.Modules.Users.Entities;

namespace way.Database
{
    public class Seed
    {
        public static async Task Initialize(DatabaseContext context)
        {
            if (context.Rooms.Any())
            {
                return;
            }

            var rooms = new Room[]
            {
                new Room { Id = 1, Name = "Animes", SeatsQuantity = 80 },
                new Room { Id = 2, Name = "Séries", SeatsQuantity = 80 },
                new Room { Id = 3, Name = "Filmes", SeatsQuantity = 80 },
            };

            await context.Rooms.AddRangeAsync(rooms);

            var user = new User[]
            {
                new User { Id = 1, Email = "joestar@gmail.com", Password = "123456", Image = "profile.jpg", Role = "Admin"}
            };

            await context.Users.AddRangeAsync(user);
            await context.SaveChangesAsync();
        }
    }
}
