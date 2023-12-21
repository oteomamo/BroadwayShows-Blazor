using BroadwayShows.Library.Models;
using BroadwayShows.Library.Services;
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
                optionsBuilder.UseSqlServer("Server=tcp:broadwayshows.database.windows.net,1433;Initial Catalog=BroadwayShows;Persist Security Info=False;User ID=legion;Password=@Database;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

                return new BroadwayShowsContext(optionsBuilder.Options);
            }
        }


        public DbSet<Shows> Shows { get; set; }
        public DbSet<TicketSales> TicketSales { get; set; }
        public DbSet<CastCrew> CastCrews { get; set; }
        public DbSet<Theater> Theaters { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<WorkingPosition> WorkingPositions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CastCrew>().HasKey(c => c.SSN);
            modelBuilder.Entity<Shows>().HasKey(c => c.ShowId);
            modelBuilder.Entity<TicketSales>().HasKey(c => c.TicketNumber);
            modelBuilder.Entity<Theater>().HasKey(c => c.TheaterId);
            modelBuilder.Entity<Genre>().HasKey(c => c.GenreId);
            modelBuilder.Entity<WorkingPosition>().HasKey(c => c.WorkingPositionID);
        }
    }
}
