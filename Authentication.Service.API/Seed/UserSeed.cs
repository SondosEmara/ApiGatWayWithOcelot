using Authentication.Service.API.Models;

namespace Authentication.Service.API.Seed
{
    public static class UserSeed
    {
        public static readonly IEnumerable<User> Users = new List<User>() 
                        {
                            new User() { userId = 1, username = "Sondos", password = "Sondso@test2", email = "sondos.emara2002@gmail.com" },
                            new User() { userId = 2, username = "Salma", password = "Sondso@test2", email = "sondos.emara2002@gmail.com" },
                            new User() { userId = 3, username = "sarah", password = "Sondso@test2", email = "sarah.emara2002@gmail.com" }
                        };
    }
}
