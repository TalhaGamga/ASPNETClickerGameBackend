using ClickerGameMVC.Entity.Entities;
using ClickerGameMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace ClickerGameMVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(u => u.UserStat)
                .WithOne(us => us.User)
                .HasForeignKey<User>(u => u.UserStatId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserStat>()
                .HasOne(us => us.User)
                .WithOne(u => u.UserStat)
                .HasForeignKey<UserStat>(us => us.UserId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<UserEvent> UserEvents { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<UserStat> UserStats { get; set; }
        public DbSet<UserItem> UserItems { get; set; }
        public DbSet<LeaderBoard> LeaderBoard { get; set; }
    }
}
