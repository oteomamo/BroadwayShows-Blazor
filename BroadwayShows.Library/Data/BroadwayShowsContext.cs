using BroadwayShows.Library.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroadwayShows.Library.Data
{
    public class BroadwayShowsContext : DbContext
    {
        public BroadwayShowsContext() { }

        public BroadwayShowsContext(DbContextOptions<BroadwayShowsContext> options)
            : base(options)
        { }
        public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<BroadwayShowsContext>
        {
            public BroadwayShowsContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<BroadwayShowsContext>();
                optionsBuilder.UseMySql("Server=127.0.0.1;Database=BroadwayShows;User ID=root;Password=@Database;Port=3306;CharSet=utf8mb4;", new MySqlServerVersion(new Version(8, 0, 21)));

                return new BroadwayShowsContext(optionsBuilder.Options);
            }
        }


        public DbSet<Shows> Shows { get; set; }
        public DbSet<TicketSales> TicketSales { get; set; }
        public DbSet<CastCrew> CastCrews { get; set; }
        public DbSet<Theater> Theaters { get; set; }

        // Optional: If you need specific configurations for models
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CastCrew>().HasKey(c => c.SSN);
            modelBuilder.Entity<Shows>().HasKey(c => c.ShowId);
            modelBuilder.Entity<TicketSales>().HasKey(c => c.TicketNumber);
            modelBuilder.Entity<Theater>().HasKey(c => c.TheaterId);
        }
    }
}
