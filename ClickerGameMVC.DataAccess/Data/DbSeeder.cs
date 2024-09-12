using ClickerGameMVC.Data;
using ClickerGameMVC.Entity.Entities;
using ClickerGameMVC.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

using BC = BCrypt.Net.BCrypt;

namespace ClickerGameMVC.DataAccess.Data
{
    public class DBSeeder
    {
        public static void Seed(ApplicationDbContext dbContext)
        {
            ArgumentNullException.ThrowIfNull(dbContext, nameof(dbContext));
            dbContext.Database.EnsureCreated();

            var executionStrategy = dbContext.Database.CreateExecutionStrategy();

            executionStrategy.Execute(
                () =>
                {
                    using (var transaction = dbContext.Database.BeginTransaction())
                    {
                        try
                        {
                            // Seed Users
                            if (!dbContext.Users.Any())
                            {
                                var usersData = File.ReadAllText("C:\\Users\\talha.gamga\\source\\repos\\ClickerGameMVC\\ClickerGameMVC.DataAccess\\Resources\\usersseeddata.json");
                                var parsedUsers = JsonConvert.DeserializeObject<User[]>(usersData);

                                foreach (var user in parsedUsers)
                                {
                                    user.Password = BC.HashPassword(user.Password);
                                }

                                dbContext.Users.AddRange(parsedUsers);
                                dbContext.SaveChanges();
                            }

                            // Seed Events
                            if (!dbContext.Events.Any())
                            {
                                var eventsData = File.ReadAllText("C:\\Users\\talha.gamga\\source\\repos\\ClickerGameMVC\\ClickerGameMVC.DataAccess\\Resources\\eventsseeddata.json");
                                var parsedEvents = JsonConvert.DeserializeObject<Event[]>(eventsData);

                                dbContext.Events.AddRange(parsedEvents);
                                dbContext.SaveChanges();
                            }

                            // Seed Items
                            if (!dbContext.Items.Any())
                            {
                                var itemsData = File.ReadAllText("C:\\Users\\talha.gamga\\source\\repos\\ClickerGameMVC\\ClickerGameMVC.DataAccess\\Resources\\itemsseeddata.json");
                                var pasedItems = JsonConvert.DeserializeObject<Item[]>(itemsData);

                                dbContext.Items.AddRange(pasedItems);
                                dbContext.SaveChanges();
                            }

                            transaction.Commit();
                        }

                        catch (Exception ex)
                        {
                            transaction.Rollback();
                        }
                    }
                });
        }
    }
}
