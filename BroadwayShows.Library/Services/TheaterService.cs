using BroadwayShows.Library.Data;
using BroadwayShows.Library.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroadwayShows.Library.Services
{
    public class TheaterService
    {
        private readonly BroadwayShowsContext _context;

        public TheaterService(BroadwayShowsContext context)
        {
            _context = context;
        }

        // Create
        public async Task CreateTheaterAsync(Theater theater)
        {
            if (theater == null) throw new ArgumentNullException(nameof(theater));

            _context.Theaters.Add(theater);
            await _context.SaveChangesAsync();
        }

        // Read (Get a single theater by ID)
        public async Task<Theater> GetShowByIdAsync(int id)
        {
            return await _context.Theaters.FindAsync(id);
        }

        // Read (Get all theaters)
        public async Task<List<Theater>> GetAllShowsAsync()
        {
            return await _context.Theaters.ToListAsync();
        }

        // Update
        public async Task UpdateShowAsync(Theater theater)
        {
            if (theater == null) throw new ArgumentNullException(nameof(theater));

            _context.Entry(theater).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        // Delete
        public async Task DeleteShowAsync(int id)
        {
            var theaterToDelete = await _context.Theaters.FindAsync(id);
            if (theaterToDelete != null)
            {
                _context.Theaters.Remove(theaterToDelete);
                await _context.SaveChangesAsync();
            }
        }

        // Get all Theaters

        public async Task<List<Theater>> GetAllTheatersAsync() // Changed method name for clarity
        {
            return await _context.Theaters.ToListAsync();
        }

        public async Task<List<string>> GetAllTheaterNamesAsync()
        {
            return await _context.Theaters.Select(theater => theater.Name).ToListAsync();
        }

        // Get Theater ID by Name
        public async Task<int?> GetTheaterIdByName(string theaterName)
        {
            var theater = await _context.Theaters.FirstOrDefaultAsync(t => t.Name == theaterName);
            return theater?.TheaterId;
        }


    }
}
